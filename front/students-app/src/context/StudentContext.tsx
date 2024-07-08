import React, { createContext, useContext, useReducer, ReactNode } from 'react';
import { Student, StudentAction } from '../types/Student';

interface StudentState {
  students: Student[];
}

const initialState: StudentState = {
  students: [],
};

interface StudentProviderProps {
  children: ReactNode;
}

const StudentContext = createContext<{
  state: StudentState;
  dispatch: React.Dispatch<StudentAction>;
}>({
  state: initialState,
  dispatch: () => undefined
});

const studentReducer = (state: StudentState, action: StudentAction): StudentState => {
  switch (action.type) {
    case 'ADD_STUDENT':
      return { ...state, students: [...state.students, action.payload] };
    case 'UPDATE_STUDENT':
      return { ...state, students: state.students.map(st => st.id === action.payload.id ? action.payload : st) };
    case 'DELETE_STUDENT':
      return { ...state, students: state.students.filter(st => st.id !== action.payload) };
    case 'SET_STUDENTS':
      return { ...state, students: action.payload };
    default:
      return state;
  }
};

export const StudentProvider: React.FC<StudentProviderProps> = ({ children }) => {
  const [state, dispatch] = useReducer(studentReducer, initialState);

  return (
    <StudentContext.Provider value={{ state, dispatch }}>
      {children}
    </StudentContext.Provider>
  );
};

export const useStudents = () => {
  const context = useContext(StudentContext);
  if (!context) {
    throw new Error('useStudents not inside StudentProvider');
  }
  return context;
};



