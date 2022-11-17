import 'bootstrap/dist/css/bootstrap.min.css';
import '../../styles/tasks.scss'
import {useEffect, useRef, useState} from "react";
import {FETCH_TYPE, fetchAPI} from "../../services/API";
import axios from "axios";
import TasksTable from "../../components/task/tasksTable";
import TasksAction from "../../components/task/tasksAction";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import TasksPagination from "../../components/task/tasksPagination";

export default () => {
    const [projects, setProjects] = useState([]);
    const [tasks, setTasks] = useState([]);
    const [project, setProject] = useState()

    const [loading, setLoading] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [tasksPerPage] = useState(4);


    const [connection, setConnection] = useState();
    const latestTask = useRef(null);
    latestTask.current = tasks;

    useEffect(() => {
        const connect = new HubConnectionBuilder()
            .withUrl("https://localhost:7123/taskhub")
            .withAutomaticReconnect()
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("TaskMessage", (message) => {
                        const updatedTable = [...latestTask.current];
                        updatedTable.push(message);
                        setTasks(updatedTable)
                    });
                })
                .catch((error) => console.log(error));
        }
    }, [connection]);

    useEffect(() => {
        fetchAPI(FETCH_TYPE.Projects)
            .then(r => {
                setProjects(r.data)
                setProject(r.data[0].id)
            })
        //fetchAPI(FETCH_TYPE.Project)
        //    .then(r => setProject(r.data))
    }, []);

    useEffect(() => {
        async function fetchAPI() {
            setLoading(true);
            const res = await axios.get(
                `https://localhost:7123/api/Task/tasklist?id=${project}`
            )
            setTasks(res.data)
        }
        if(project !== undefined){
            fetchAPI()
                .then((res) => {})
        }
        setLoading(false);
    }, [project, ]);

    const indexOfLastTask = currentPage * tasksPerPage;
    const indexOfFirstTask = indexOfLastTask - tasksPerPage;
    const currentTasks = tasks.slice(indexOfFirstTask, indexOfLastTask);

    const paginate = pageNumber => setCurrentPage(pageNumber);

    return(
        <div className="tasks">
            <TasksAction projects={projects} setProject={setProject} tasks={tasks} setTasks={setTasks}/>
            <TasksTable tasks={currentTasks} loading={loading} currentPage={currentPage}/>
            <TasksPagination
                tasksPerPage={tasksPerPage}
                totalTasks={tasks.length}
                paginate={paginate}
            />
        </div>
    )
}