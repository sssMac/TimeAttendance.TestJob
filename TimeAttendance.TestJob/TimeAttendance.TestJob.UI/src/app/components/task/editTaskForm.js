import React, {useState} from 'react';
import Modal from "react-bootstrap/Modal";
import Form from "react-bootstrap/Form";
import Select from "react-bootstrap/FormSelect";
import Button from "react-bootstrap/Button";
import {useFormik} from "formik";
import * as yup from "yup";
import moment from "moment";
import axios from "axios";
import {useNavigate} from "react-router-dom";
import "../../styles/editTask.scss"

const EditTaskForm = (props) => {
    const [type, setType] = useState(props.task[0].comme === null ? "" : props.task[0].comme.commentType === 0 ? "text" : "file")
    const navigate = useNavigate();
    console.log()
    const formik = useFormik({
        initialValues:{
            id: props.task[0].task.id,
            taskName: props.task[0].task.taskName,
            projectId: props.task[0].task.projectId,
            startDate: `${new Date(props.task[0].task.startDate).getHours().toString().padStart(2,"0")}:${new Date(props.task[0].task.startDate).getMinutes().toString().padStart(2,"0")}`,
            cancelDate: `${new Date(props.task[0].task.cancelDate).getHours().toString().padStart(2,"0")}:${new Date(props.task[0].task.cancelDate).getMinutes().toString().padStart(2,"0")}`,
            commentId: props.task[0].comme === null ? "" : props.task[0].comme.id,
            commentType : type,
            stringContent: props.task[0].comme === null || props.task[0].comme.commentType !== 0? "" : window.atob(props.task[0].comme.content).toString(),
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
            formData.append("id", formik.values.id);
            formData.append("taskName", formik.values.taskName);
            formData.append("projectId", formik.values.projectId);
            formData.append("startDate", formik.values.startDate);
            formData.append("cancelDate", formik.values.cancelDate);
            formData.append("commentId", formik.values.commentId);
            formData.append("commentType", formik.values.commentType);
            formData.append("stringContent", formik.values.stringContent);
            formData.append("fileContent", formik.values.fileContent);
            await axios.put(
                `https://localhost:7123/api/Task/updatetask`, formData
            ).then(res => {
                console.log(res)
            })
        },

    })

    return (
        <div className="edit">
            <Modal.Header>
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
                                props.projects
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
                            value={formik.values.stringContent}
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
                    {
                        props.task[0].comme !== null && props.task[0].comme.commentType === 1 ?
                            props.task[0].comme.content !== undefined ?
                                <img src={`data:image/jpeg;base64,${props.task[0].comme.content}`} />
                                : <div></div>
                                : <div></div>
                    }
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="success" type="submit" >Save</Button>
                    <Button onClick={() => navigate('/', {replace: true})}>
                        Close
                    </Button>
                </Modal.Footer>
            </form>
        </div>
    );
};

export default EditTaskForm;