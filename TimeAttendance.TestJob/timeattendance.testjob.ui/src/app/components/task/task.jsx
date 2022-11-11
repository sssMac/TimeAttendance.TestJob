import React from 'react';

const Task = (props) => {
    return (
        <tr>
            <td>props.Counter </td>
            <td>props.time</td>
            <td>props.taskName</td>
            <td>props.desc</td>
            <td>props.start</td>
            <td>props.end</td>
        </tr>
    );
};

export default Task;