import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';
import './tasks.scss'
export default () => {
    return(<div className="Tasks">
            <Table striped bordered hover >
                <thead>
                <tr>
                    <th>#</th>
                    <th>Times</th>
                    <th>Ticket</th>
                    <th>Description</th>
                    <th>Start</th>
                    <th>End</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>1</td>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>Otto</td>
                </tr>


                </tbody>
            </Table>
        </div>
    )
}