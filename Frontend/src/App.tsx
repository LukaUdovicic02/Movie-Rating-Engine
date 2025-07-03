import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import "./index.css";
import ContentPage from "./features/content/ContentPage";
import ContentDetail from "./features/content/ContentDetail";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<ContentPage />} />
        <Route path="/content/:id" element={<ContentDetail />} />
      </Routes>
    </Router>
  );
}

export default App;
