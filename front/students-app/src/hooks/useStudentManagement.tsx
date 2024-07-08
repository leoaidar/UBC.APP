import { useContext } from 'react';
import { useStudents } from '../context/StudentContext'; 
import { NavigateFunction } from 'react-router-dom'; 
import { Student } from '../types/Student';

const useStudentManagement = () => {
  
  const { dispatch } = useStudents(); 

  const saveStudent = (student: Student, navigate: NavigateFunction) => {
    if (student.id) {
      dispatch({ type: 'UPDATE_STUDENT', payload: student });
    } else {
      dispatch({ type: 'ADD_STUDENT', payload: student });
    }
    navigate('/students'); 
  };

  return { saveStudent };
};

export default useStudentManagement;