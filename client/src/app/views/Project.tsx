import React, { useEffect, useState } from "react";
import * as projectsApi from "../api/projects.api";
import { useParams } from "react-router-dom";
import {
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
  Typography,
  Alert,
  AlertTitle,
  Collapse,
} from "@mui/material";
import RegisterTimeDialog from "./RegisterTimeDialog";

export default function ProjectView() {
  const [dialogOpen, setDialogOpen] = React.useState(false);
  const [timeRegistrations, setTimeRegistrations] = useState<any[]>([]);
  const [project, setProject] = useState<any>([]);
  const [error, setError] = useState<any>({ open: false });
  const { id } = useParams();

  const loadTimeRegistrations = () =>
    projectsApi.getTimeRegistrations(id).then((p) => {
      setTimeRegistrations(p);
    });

  useEffect(() => {
    if (!id) return;
    loadTimeRegistrations();
    projectsApi.get(id).then((p) => setProject(p));
  }, []);

  const handleClickOpen = () => {
    setDialogOpen(true);
  };

  const handleClose = (data: any) => {
    if (!!data) {
      projectsApi
        .registerTime(project.id, data)
        .then(() => loadTimeRegistrations())
        .catch((err) => {
          setError({ open: true, message: err.errorMessage });
          setTimeout(() => {
            setError({ open: false });
          }, 5000);
        });
    }
    setDialogOpen(false);
  };

  return (
    <>
      <Collapse in={error.open}>
        <Alert severity="error" sx={{ m: 2 }}>
          <AlertTitle>Error</AlertTitle>
          {error.message}
        </Alert>
      </Collapse>

      <Typography variant="h2">{project.name}</Typography>
      <Button onClick={handleClickOpen}>Register time</Button>
      <RegisterTimeDialog open={dialogOpen} handleClose={handleClose} />
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>#</TableCell>
            <TableCell>Description</TableCell>
            <TableCell>Date</TableCell>
            <TableCell>Duration</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {timeRegistrations.map((row, index) => (
            <TableRow key={row.name} sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
              <TableCell>{index + 1}</TableCell>
              <TableCell>{row.description}</TableCell>
              <TableCell>{row.date}</TableCell>
              <TableCell>{`${row.minutes} min`}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </>
  );
}
