import React, {useEffect, useRef, useState} from 'react';
import {useFormik} from "formik";
import * as yup from "yup";
import 'bootstrap/dist/css/bootstrap.min.css';
import Select from 'react-bootstrap/FormSelect';
import "../../styles/addTask.scss"
import Form from 'react-bootstrap/Form';
import TimePicker from 'react-time-picker';
import moment, {defaultFormat} from "moment";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {FETCH_TYPE, fetchAPI} from "../../services/API";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";

const AddTask = (props) => {
    const [projects, setProjects] = useState([]);
    const [type, setType] = useState("")

    const latestTask = useRef(null)
    const [connection, setConnection] = useState();

    useEffect(() => {
        fetchAPI(FETCH_TYPE.Projects)
            .then(r => setProjects(r.data))

        const connect = new HubConnectionBuilder()
            .withUrl("https://localhost:7123/websocket")
            .withAutomaticReconnect()
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("ReceiveTask", (task) => {
                        const updatedTable = [...latestTask.current];
                        updatedTable.push(task);

                        setProjects(updatedTable);
                        console.log(task)
                    });
                })
                .catch((error) => console.log(error));
        }
    }, [connection]);

    const formik = useFormik({
        initialValues:{
            taskName: "",
            project: "",
            startDate: new Date().setHours(0,0),
            endDate: new Date().setHours(24,0),
            commType : "",
            comm: ""
        },validationSchema: yup.object({
            taskName: yup.string().required("task name cannot be empty").max(255),
            project: yup.string().required("project cannot be empty").max(255),
            startDate: yup.string().required("start time cannot be empty"),
            endDate: yup
                .string()
                .required("end time cannot be empty")
                .test("is-greater", "end time should be greater", function(value) {
                    const { startDate } = this.parent;
                    return moment(value, "HH:mm").isSameOrAfter(moment(startDate, "HH:mm"));
                }),
            commType: yup.string(),
        }),
        onSubmit: async function () {
            console.log(formik.values)
            if (connection){
                await connection.send("SendTaskObj", formik.values);}

            formik.resetForm();
        },

    })

    return (
        <div>
            <Modal.Header closeButton>
            </Modal.Header>
            <form className="form" onSubmit={formik.handleSubmit} onReset={formik.handleReset}>
                <Modal.Body>
                    <Form.Group controlId="formName">
                        <Form.Label>Task name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter name"
                            className="input"
                            name="taskName"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.taskName}
                            isInvalid={!!formik.errors.taskName}
                            autoComplete="off"
                        />
                        <Form.Control.Feedback type="invalid">{formik.errors.taskName}</Form.Control.Feedback>
                        <Form.Label>Project</Form.Label>
                        <Select
                            className="input"
                            name="project"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.project}
                            isInvalid={!!formik.errors.project}

                        >
                            <option value="" label='Choose project...'> </option>
                            {
                                projects
                                    .map(x => <option
                                        key={x.id}
                                        value={x.id}>
                                        {x.projectName}
                                    </option>)
                            }
                        </Select>
                        <Form.Control.Feedback type="invalid">{formik.errors.project}</Form.Control.Feedback>

                        <Form.Label>Start</Form.Label>
                        <Form.Control
                            type="time"
                            name="startDate"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.startDate}
                            isInvalid={!!formik.errors.startDate}
                            autoComplete="off"
                        />
                        <Form.Control.Feedback type="invalid">{formik.errors.startDate}</Form.Control.Feedback>

                        <Form.Label>End</Form.Label>
                        <Form.Control
                            type="time"
                            name="endDate"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.endDate}
                            isInvalid={!!formik.errors.endDate}
                            autoComplete="off"
                        />
                        <Form.Control.Feedback type="invalid">{formik.errors.endDate}</Form.Control.Feedback>
                        <Form.Label>Type of comment</Form.Label>
                        <Select
                            className="input"
                            name="commType"
                            onChange={(e) => {
                                formik.handleChange(e)
                                setType(e.target.value)
                                formik.values.comm = ""
                            }}
                            onBlur={formik.handleBlur}
                            value={type}
                        >
                            <option value="" label='With out comment'> </option>
                            <option value="text" label='Text'> </option>
                            <option value="file" label='File'> </option>
                        </Select>
                        <Form.Label>Comment</Form.Label>
                        <Form.Control
                            type={type}
                            as={type === "text" ? "textarea" : "input"}
                            name="comm"
                            disabled={type === ""}
                            onChange={e => {
                                type === "text" ?
                                    formik.handleChange(e)
                                    : formik.setFieldValue("comm", e.target.files[0])
                            }}
                            onBlur={formik.handleBlur}
                            isInvalid={!!formik.errors.comm}
                            autoComplete="off"
                        />
                    </Form.Group>
                    <Form.Control.Feedback type="invalid">{formik.errors.comm}</Form.Control.Feedback>

                </Modal.Body>
                <Modal.Footer>
                    <Button variant="success" type="submit" >Create</Button>
                    <Button onClick={() => {
                    }}>Close</Button>
                </Modal.Footer>
            </form>
        </div>
    );
};

export default AddTask;