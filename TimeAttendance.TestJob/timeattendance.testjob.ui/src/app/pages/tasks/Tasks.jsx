import Table from 'react-bootstrap/Table';

export default () => <>
    <Table striped bordered hover>
        <thead>
        <tr>
            <th>#</th>
            <th >Times</th>
            <th colSpan={10}>Ticket</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>1</td>
            <td>Mark</td>
            <td>Otto</td>
        </tr>

        </tbody>
    </Table>
</>