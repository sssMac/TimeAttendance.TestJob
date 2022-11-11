import './App.css';
import {Routes, Route} from "react-router-dom";
import Tasks from "./app/pages/tasks/Tasks";

function App() {
  return (
    <div className="App">
        <Routes>
            <Route path="/" element={<Tasks />} >
                <Route index element={<Tasks />} />
            </Route>
        </Routes>
    </div>
  );
}

export default App;
