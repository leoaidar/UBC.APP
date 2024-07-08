export interface Student {
    id?: number;           
    name: string;
    age: number;
    grade: number;
    averageGrade: number;
    address: string;
    fatherName?: string;   
    motherName?: string;   
    birthDate: Date;
  }
  
  export type StudentAction =
    | { type: 'ADD_STUDENT'; payload: Student }
    | { type: 'UPDATE_STUDENT'; payload: Student }
    | { type: 'DELETE_STUDENT'; payload: number }
    | { type: 'SET_STUDENTS'; payload: Student[] };
  
  export interface StudentState {
    students: Student[];
  }