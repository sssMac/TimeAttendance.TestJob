import React, {useEffect, useRef, useState} from 'react';
import {useFormik} from "formik";
import * as yup from "yup";
import 'bootstrap/dist/css/bootstrap.min.css';
import Select from 'react-bootstrap/FormSelect';
import "../../styles/addTask.scss"
import Form from 'react-bootstrap/Form';
import moment from "moment";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import axios from "axios";
import {FETCH_TYPE, fetchAPI} from "../../services/API";

const AddTask = (props) => {
    const [projects, setProjects] = useState([]);
    const [type, setType] = useState("")
    const latestTask = useRef(null);
    latestTask.current = props.tasks;
    useEffect(() => {
        fetchAPI(FETCH_TYPE.Projects)
            .then(r => {
                setProjects(r.data)
            })
    }, []);

    const formik = useFormik({
        initialValues:{
            taskName: "",
            projectId: "",
            startDate: new Date().setHours(0,0),
            cancelDate: new Date().setHours(22,0),
            commentType : "",
            stringContent: "",
            fileContent: ""
        },validationSchema: yup.object({
            taskName: yup.string().required("task name cannot be empty").max(255),
            projectId: yup.string().required("project cannot be empty").max(255),
            startDate: yup.string().required("start time cannot be empty"),
            cancelDate: yup
                .string()
                .required("end time cannot be empty")
                .test("is-greater", "end time should be greater", function(value) {
                    const { startDate } = this.parent;
                    return moment(value, "HH:mm").isSameOrAfter(moment(startDate, "HH:mm"));
                }),
            commentType: yup.string(),
        }),
        onSubmit: async function () {
            console.log(formik.values)
            const formData = new FormData();
            formData.append("taskName", formik.values.taskName);
            formData.append("projectId", formik.values.projectId);
            formData.append("startDate", formik.values.startDate);
            formData.append("cancelDate", formik.values.cancelDate);
            formData.append("commentType", formik.values.commentType);
            formData.append("stringContent", formik.values.stringContent);
            formData.append("fileContent", formik.values.fileContent);
            await axios.post(
                `https://localhost:7123/api/Task/addnewtask`, formData
            ).then(res => {
                console.log(res)
            })
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
                            name="projectId"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.projectId}
                            isInvalid={!!formik.errors.projectId}

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
                        <Form.Control.Feedback type="invalid">{formik.errors.projectId}</Form.Control.Feedback>

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
                            name="cancelDate"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.cancelDate}
                            isInvalid={!!formik.errors.cancelDate}
                            autoComplete="off"
                        />
                        <Form.Control.Feedback type="invalid">{formik.errors.cancelDate}</Form.Control.Feedback>
                        <Form.Label>Type of comment</Form.Label>
                        <Select
                            className="input"
                            name="commentType"
                            onChange={(e) => {
                                formik.handleChange(e)
                                setType(e.target.value)
                                formik.values.stringContent = ""
                                formik.values.fileContent = ""
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
                            type={type === "text" ? type : "hidden"}
                            as={type === "text" ? "textarea" : "input"}
                            name="stringContent"
                            disabled={type !== "text"}
                            onChange={e => { formik.setFieldValue("stringContent",e.target.value)}}
                            onBlur={formik.handleBlur}
                            isInvalid={!!formik.errors.stringContent }
                            autoComplete="off"

                        />
                        <Form.Control
                            type={type === "file" ? type : "hidden"}
                            as="input"
                            name="fileContent"
                            disabled={type !== "file"}
                            onChange={e => { formik.setFieldValue("fileContent",e.target.files[0])}}
                            onBlur={formik.handleBlur}
                            isInvalid={!!formik.errors.fileContent}
                            autoComplete="off"
                        />
                    </Form.Group>
                    <Form.Control.Feedback type="invalid">{formik.errors.stringContent}</Form.Control.Feedback>
                    <Form.Control.Feedback type="invalid">{formik.errors.fileContent}</Form.Control.Feedback>

                </Modal.Body>
                <Modal.Footer>
                    <Button variant="success" type="submit" >Create</Button>
                    <Button onClick={() => { props.setModalShow(false) }}>Close</Button>
                </Modal.Footer>
            </form>
        </div>
    );
};

export default AddTask;