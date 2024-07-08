import React, { useEffect, useState } from 'react';
import { Modal, Button, ListGroup, ListGroupItem, Container, Row, Col } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import { Student } from '../types/Student';
import { useSnackbar } from 'notistack';
import { ToastContainer, toast } from 'react-toastify';  
import 'react-toastify/dist/ReactToastify.css';  
import { studentDeleteService, studentListService } from '../services/studentsService';

const StudentList: React.FC = () => {
  const [students, setStudents] = useState<Student[]>([]);
  const [studentToDelete, setStudentToDelete] = useState<Student | null>(null);
  const [showDelete, setShowDelete] = useState(false);
  const [showLogout, setShowLogout] = useState(false); 
  const { enqueueSnackbar } = useSnackbar(); 
  const { token, logout } = useAuth(); 
  const navigate = useNavigate();

  const handleCloseDelete = () => setShowDelete(false);
  const handleCloseLogout = () => setShowLogout(false); 
  const handleShowLogout = () => setShowLogout(true); 

  const handleShowDelete = (student: Student) => {
    setStudentToDelete(student);
    setShowDelete(true);
  };

  const fetchStudents = async () => {
    try {
      const response = await studentListService();      
      setStudents(response);
    } catch (error) {
      console.error('Falha ao listar estudantes.', error);
      enqueueSnackbar('Falha ao listar estudantes.', { variant: 'error' });
      toast.error('Falha ao listar estudantes.'); 
    }
  };

  const handleDelete = async () => {
    if (studentToDelete && studentToDelete.id) {
      try {
        const response = await studentDeleteService(studentToDelete.id);
        const message = response.message || 'Estudante apagado com sucesso!'; 
        enqueueSnackbar('Estudante apagado com sucesso!', { variant: 'success' });
        toast.success(message);  
        fetchStudents(); 
      } catch (error) {
        console.error('Falha ao apagar estudante.', error);
        enqueueSnackbar('Falha ao apagar estudante.', { variant: 'error' });
        toast.error('Falha ao apagar estudante.'); 
      }
    }
    handleCloseDelete();
  };
 
  useEffect(() => {
    fetchStudents();
  }, [token]);

  const handleLogoutConfirm = () => {
    logout();
    navigate('/');
    handleCloseLogout();
  };

  return (
    <Container className="mt-3">
      <Row className="mb-3">
        <Col>
          <h2>Lista de Estudantes</h2>
        </Col>
        <Col className="text-right">
          <Button variant="primary" onClick={() => navigate('/add-student')}>Adicionar Novo Estudante</Button>
          <Button variant="secondary" onClick={handleShowLogout} className="ms-2">Sair</Button>
        </Col>
      </Row>
      <ListGroup>
        {students.length === 0 ? (
          <div className="text-center">Nenhum Estudante encontrado.</div>
        ) : (
          students.map((student) => (
            <ListGroupItem key={student.id} className="d-flex justify-content-between align-items-center">
              {student.name} - Série: {student.grade}, Idade: {student.age}
              <div>
                <Link to={`/edit-student/${student.id}`} className="btn btn-primary me-2">Atualizar</Link>
                <Button variant="danger" onClick={() => handleShowDelete(student)}>Apagar</Button>
              </div>
            </ListGroupItem>
          ))
        )}
      </ListGroup>
      <Modal show={showDelete} onHide={handleCloseDelete}>
        <Modal.Header closeButton>
          <Modal.Title>Confirma Deleção</Modal.Title>
        </Modal.Header>
        <Modal.Body>Tem certeza que quer deletar {studentToDelete?.name}?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseDelete}>
            Cancelar
          </Button>
          <Button variant="danger" onClick={handleDelete}>
            Deletar
          </Button>
        </Modal.Footer>
      </Modal>
      <Modal show={showLogout} onHide={handleCloseLogout}>
        <Modal.Header closeButton>
          <Modal.Title>Confirma Sair</Modal.Title>
        </Modal.Header>
        <Modal.Body>Tem certeza que deseja fazer o logout?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseLogout}>
            Cancelar
          </Button>
          <Button variant="danger" onClick={handleLogoutConfirm}>
            Logout
          </Button>
        </Modal.Footer>
      </Modal>            
      <ToastContainer position="top-right" autoClose={5000} hideProgressBar={false} newestOnTop={false} closeOnClick rtl={false} pauseOnFocusLoss draggable pauseOnHover />
    </Container>
  );
};

export default StudentList;