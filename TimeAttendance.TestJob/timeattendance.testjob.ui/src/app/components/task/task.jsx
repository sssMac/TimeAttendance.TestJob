import React from 'react';

const Task = (props) => {
    console.log(new Date(props.task.task.cancelDate))

    const start = new Date(props.task.task.startDate)
    const cancel = new Date(props.task.task.cancelDate)
    const elapsed = new Date(start.getTime() + Date.now() - cancel.getTime())
    const startDate = `${start.getHours().toString().padStart(2,"0")}:${start.getMinutes().toString().padStart(2,"0")}`
    const cancelDate = `${cancel.getHours().toString().padStart(2,"0")}:${cancel.getMinutes().toString().padStart(2,"0")}`
    const elapsedDate = `${elapsed.getHours().toString().padStart(2,"0")}:${elapsed.getMinutes().toString().padStart(2,"0")}`

    return (
            <tr>
            <td>{props.index + 1}</td>
            <td>{elapsedDate}</td>
            <td>{props.task.task.taskName}</td>
            <td>{props.task.comme === null ? "" : props.task.comme.content}</td>
            <td>{startDate}</td>
            <td>{cancelDate}</td>
        </tr>
        );
};

export default Task;