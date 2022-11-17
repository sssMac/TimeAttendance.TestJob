import React, {useEffect, useState} from 'react';
import Select from "react-bootstrap/FormSelect";
import Button from "react-bootstrap/Button";
import MyModal from "../modal/modal";
import AddTask from "./addTask";
import 'bootstrap/dist/css/bootstrap.min.css';

const TasksAction = (props) => {
    const [modalShow, setModalShow] = useState(false);


    return (
        <div className="actions">
            <div className="left">
                <Select
                    className="proj_selector"
                    onChange={e => props.setProject(e.target.value)}

                >
                    {props.projects.map(value =>
                        <option key={value.id} value={value.id}>
                            {value.projectName}
                        </option>)}
                </Select>
            </div>
            <div className="right">
                <Button variant="success"
                        onClick={() => setModalShow(true)}>
                    New Task
                </Button>

            </div>
            <MyModal
                show={modalShow}
                onHide={() => setModalShow(false)}
                child={<AddTask key={props.projects.length} tasks={props.tasks} setTasks={props.setTasks} setModalShow={setModalShow} onHide={() => setModalShow(false)} />}
            />
        </div>
    );
};

export default TasksAction;
