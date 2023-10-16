import * as React from "react";
import Projects from "./views/Projects";
import "./style.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import ProjectView from "./views/Project";

export default function App() {
  return (
    <>
      <header className="bg-gray-900 text-white flex items-center h-12 w-full">
        <div className="container mx-auto">
          <a className="navbar-brand" href="/">
            Timelogger
          </a>
        </div>
      </header>

      <main>
        <div className="container mx-auto">
          <BrowserRouter>
            <Routes>
              <Route path="/project">
                <Route path=":id" element={<ProjectView />}></Route>
              </Route>
              <Route path="/" element={<Projects />}></Route>
            </Routes>
          </BrowserRouter>
        </div>
      </main>
    </>
  );
}
