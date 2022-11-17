import React, {useEffect, useState} from 'react';
import {useLocation, useParams} from "react-router-dom";
import {useFormik} from "formik";
import * as yup from "yup";
import moment from "moment/moment";
import axios from "axios";
import "../../styles/addTask.scss"
import 'bootstrap/dist/css/bootstrap.min.css';
import {FETCH_TYPE, fetchAPI} from "../../services/API";
import EditTaskForm from "../../components/task/editTaskForm";


const EditTask = (_) => {
    const { id } = useParams()
    const [projects, setProjects] = useState([]);
    const [task, setTask] = useState()

    useEffect(() => {
        async function fetchAPI() {
            const res = await axios.get(
                `https://localhost:7123/api/Task/task?id=${id}`
            )
            setTask(res.data)
        }
        fetchAPI()
            .then((res) => {})
    },[]);

    useEffect(() => {
        fetchAPI(FETCH_TYPE.Projects)
            .then(r => {
                setProjects(r.data)
            })
    }, []);



    if(task !== undefined && projects !== undefined){
        return(
            <div>
                <EditTaskForm task={task} projects={projects}/>
            </div>
        )
    }
    else{
        return (
            <div>
                LOADING...
            </div>
        );
    }

};

export default EditTask;