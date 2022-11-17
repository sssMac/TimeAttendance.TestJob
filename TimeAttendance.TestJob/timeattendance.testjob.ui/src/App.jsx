import './App.css';
import {Routes, Route} from "react-router-dom";
import Tasks from "./app/pages/tasks/Tasks";
import EditTask from "./app/pages/editTask/editTask";

function App() {
  return (
    <div className="App">
        <Routes>
            <Route path="/" element={<Tasks />} />
            <Route path="/editTask/:id" element={<EditTask />} />

        </Routes>
    </div>
  );
}

export default App;
