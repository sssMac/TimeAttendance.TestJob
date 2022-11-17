import React from 'react';
import Task from "./task";
import Table from "react-bootstrap/Table";


const TasksTable = (props) => {
    if (props.loading) {
        return <h2>Loading...</h2>;
    }
    return (
            <Table striped bordered hover >
                <thead>
                <tr>
                    <th></th>
                    <th>#</th>
                    <th>Times</th>
                    <th>Ticket</th>
                    <th>Description</th>
                    <th>Start</th>
                    <th>End</th>
                </tr>
                </thead>
                <tbody>
                {
                    props.tasks
                        .map((value,i) => <Task key={i*200} task={value} index={i}/>)
                }
                </tbody>
            </Table>
    );
};

export default TasksTable;