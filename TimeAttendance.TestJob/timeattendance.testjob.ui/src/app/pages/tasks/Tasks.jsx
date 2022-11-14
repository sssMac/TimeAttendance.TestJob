import 'bootstrap/dist/css/bootstrap.min.css';
import '../../styles/tasks.scss'
import {useEffect, useState} from "react";
import {FETCH_TYPE, fetchAPI} from "../../services/API";
import axios from "axios";
import TasksTable from "../../components/task/tasksTable";
import TasksAction from "../../components/task/tasksAction";

export default () => {
    const [projects, setProjects] = useState([]);
    const [tasks, setTasks] = useState([]);
    const [project, setProject] = useState()


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
            const res = await axios.get(
                `https://localhost:7123/api/Task/tasklist?id=${project}`
            )
            setTasks(res.data)
        }
        if(project !== undefined){
            fetchAPI()
                .then((res) => {})
        }

    }, [project]);

    return(
        <div className="tasks">
            <TasksAction projects={projects} setProject={setProject} />
            <TasksTable tasks={tasks}/>
        </div>
    )
}