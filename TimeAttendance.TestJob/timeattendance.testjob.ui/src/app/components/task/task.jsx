import React from 'react';
import { Link } from 'react-router-dom';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import { faPencil } from '@fortawesome/free-solid-svg-icons'
import "../../styles/task.scss"
import moment from "moment";
const Task = (props) => {
    const start = new Date(props.task.task.startDate)
    const cancel = new Date(props.task.task.cancelDate)
    const elapsed = new Date(moment((moment(cancel).subtract(start.getHours(), 'h').format())).subtract(start.getMinutes(), "m").format())
    const startDate = `${start.getHours().toString().padStart(2,"0")}:${start.getMinutes().toString().padStart(2,"0")}`
    const cancelDate = `${cancel.getHours().toString().padStart(2,"0")}:${cancel.getMinutes().toString().padStart(2,"0")}`
    const elapsedDate = `${elapsed.getHours().toString().padStart(2,"0")}:${elapsed.getMinutes().toString().padStart(2,"0")}`



    return (
        <tr>
            <td>
                <Link to={`/editTask/${props.task.task.id}`}>
                    <FontAwesomeIcon icon={faPencil} />
                </Link>
            </td>
            <td>{props.index + 1}</td>
            <td>{elapsedDate}</td>
            <td>{props.task.task.taskName}</td>
            <td>{ props.task.comme !== null ?
                    props.task.comme.commentType === 0 ?
                        window.atob(props.task.comme.content).toString()
                        : <img src={`data:image/jpeg;base64,${props.task.comme.content}`} />
                    : ""
                 } </td>
            <td>{startDate}</td>
            <td>{cancelDate}</td>
        </tr>
    );
};

export default Task;