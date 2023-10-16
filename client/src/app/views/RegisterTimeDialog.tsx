import * as React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { useState } from "react";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { Box } from "@mui/material";

export default function FormDialog(props: { open: boolean; handleClose: (data: any) => void }) {
  const [data, setData] = useState<any>({});

  const handleChange = (field: string, value: any) => {
    data[field] = value;
    setData(data);
  };

  const handleDateChange = (field: string, value: any) => {
    const stringDateTime = value.$d.toJSON();
    const dateOnly = stringDateTime.slice(0, stringDateTime.indexOf("T"));
    handleChange(field, dateOnly);
  };

  return (
    <div>
      <Dialog open={props.open} onClose={props.handleClose}>
        <DialogTitle>Register time</DialogTitle>
        <DialogContent>
          <TextField
            id="description"
            label="Description"
            fullWidth
            variant="outlined"
            onChange={(event) => handleChange("description", event.target.value)}
            margin="normal"
          />
          <TextField
            type="number"
            inputProps={{ inputMode: "numeric", pattern: "[0-9]*" }}
            id="duration"
            label="Duration"
            variant="outlined"
            onChange={(event) => handleChange("minutes", event.target.value)}
            margin="normal"
          />
          <Box mt={1}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                onChange={(value: any) => {
                  handleDateChange("date", value);
                }}
              />
            </LocalizationProvider>
          </Box>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => props.handleClose(null)}>Cancel</Button>
          <Button onClick={() => props.handleClose(data)}>Save</Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
