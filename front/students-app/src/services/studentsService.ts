
import { Student } from '../types/Student';
import axiosClient from '../utils/axiosClient';

export const studentListService = async ():Promise<Student[]> => {
  const response = await axiosClient.get<Student[]>('/Students');
  return response.data;
};

export const studentDeleteService = async (id: number):Promise<any> => {
  const response = await axiosClient.delete(`/Students/${id}`);
  return response.data;
};

export const studenGetService = async (id: string):Promise<Student> => {
  const response = await axiosClient.get<Student>(`/Students/${id}`);
  return response.data;
};

export const studentUpdateService = async (id: string, studentData: Student):Promise<any> => {
  const response = await axiosClient.put(`/Students/${id}`, studentData);
  return response.data;
};

export const studentAddService = async (studentData: Student):Promise<any> => {
  const response = await axiosClient.post(`/Students`, studentData);
  return response.data;
};
