import { Project } from "../models/project.model";

const BASE_URL = "http://localhost:5172/api";

export async function getAll(sort: any): Promise<Project[]> {
  let url = `${BASE_URL}/projects`;
  if (sort) {
    url = url + `?orderBy=${sort.orderBy}&dir=${sort.dir}`;
  }
  const response = await fetch(url);
  return response.json();
}

export async function getTimeRegistrations(projectId: any): Promise<any[]> {
  let url = `${BASE_URL}/projects/${projectId}/timeRegistrations`;
  const response = await fetch(url);
  return response.json();
}

export async function get(id: string): Promise<any> {
  let url = `${BASE_URL}/projects/${id}`;
  const response = await fetch(url);
  return response.json();
}

export async function registerTime(id: any, data: any): Promise<any> {
  let url = `${BASE_URL}/timeRegistrations`;
  const body = {
    ...data,
    projectId: id,
  };
  var response = await fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  });
  if (!response.ok) {
    throw await response.json();
  }
}
