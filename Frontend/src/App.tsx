import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import "./index.css";
import ContentPage from "./features/content/ContentPage";
import ContentDetailPage from "./features/content/ContentDetailPage";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<ContentPage />} />
        <Route path="/content/:id" element={<ContentDetailPage />} />
      </Routes>
    </Router>
  );
}

export default App;
