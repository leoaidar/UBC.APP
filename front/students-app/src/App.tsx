import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './components/Login';
import StudentList from './components/StudentList';
import StudentForm from './components/StudentForm';
import { AuthProvider } from './context/AuthContext';
import { StudentProvider } from './context/StudentContext';
import useStudentManagement from './hooks/useStudentManagement';
import Home from './pages/Home';

const App: React.FC = () => {
  const { saveStudent } = useStudentManagement();

  return (
    <Router>
      <AuthProvider>
        <StudentProvider>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/students" element={<StudentList />} />
            <Route path="/edit-student/:id" element={<StudentForm onSave={saveStudent} />} />
            <Route path="/add-student" element={<StudentForm onSave={saveStudent} />} />
          </Routes>
        </StudentProvider>
      </AuthProvider>
    </Router>
  );
};

export default App;