import React, { useEffect, useState } from "react";
import * as projectsApi from "../api/projects.api";
import { Project } from "../models/project.model";
import { Sort } from "../models/sort.model";
import { Table, TableHead, TableRow, TableCell, TableBody } from "@mui/material";

export default function Projects() {
  const [sort, setSort] = useState<Sort | null>(null);
  const [projects, setProjects] = useState<Project[]>([]);
  useEffect(() => {
    projectsApi.getAll(sort).then((p) => {
      setProjects(p);
    });
  }, [sort]);
  const deadlineSort = () => {
    const dir = sort?.dir != "ascending" ? "ascending" : "descending";
    setSort({ orderBy: "deadline", dir });
  };
  return (
    <>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>#</TableCell>
            <TableCell>Description</TableCell>
            <TableCell>Date</TableCell>
            <TableCell>
              <a className="sortable" onClick={deadlineSort}>
                Deadline
              </a>
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {projects.map((row, index) => (
            <TableRow key={row.name} sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
              <TableCell>{index + 1}</TableCell>
              <TableCell>
                <a href={"/project/" + row.id}>{row.name}</a>
              </TableCell>
              <TableCell>{row.customerName}</TableCell>
              <TableCell>{row.deadline}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </>
  );
}
