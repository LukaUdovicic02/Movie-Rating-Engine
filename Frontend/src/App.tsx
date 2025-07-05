import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import "./index.css";
import ContentPage from "./features/content/ContentPage";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<ContentPage />} />
      </Routes>
    </Router>
  );
}

export default App;
