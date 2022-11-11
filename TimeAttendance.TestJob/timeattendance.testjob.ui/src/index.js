import {StrictMode} from 'react';
import './index.css';
import {createRoot} from "react-dom/client";
import App from './App';
import {BrowserRouter} from "react-router-dom";

const root = createRoot(document.getElementById('root'));
root.render(
  <StrictMode>
      <BrowserRouter>
          <App />
      </BrowserRouter>
  </StrictMode>
);
