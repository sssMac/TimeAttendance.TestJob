import axios from "axios";

const FETCH_TYPE = {
    Projects : 'https://localhost:7123/api/Project/projectlist',
    Tasks : 'https://localhost:7123/api/Task/tasklist?',
    Project : 'https://localhost:7123/api/Project/project',
    Task : 'https://localhost:7123/api/Tasks/task',
    TaskComments : 'https://localhost:7123/api/Tasks/taskcomments',
}

async function fetchAPI(type) {
    return await axios(
        type,
    );
}


export {
    fetchAPI, FETCH_TYPE
}