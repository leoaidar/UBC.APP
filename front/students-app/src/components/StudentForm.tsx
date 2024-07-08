import React, { useState, useEffect } from 'react';
import { Form, Modal, Button, Container, Row, Col } from 'react-bootstrap';
import { useNavigate, useParams, Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import { Student } from '../types/Student';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { studenGetService, studentAddService, studentUpdateService } from '../services/studentsService';

type NavigateFunction = ReturnType<typeof useNavigate>;

interface StudentFormProps {
  onSave: (student: Student, navigate: NavigateFunction) => void;
}

const calculateAge = (birthDate: Date) => {
  const today = new Date();
  const birth = new Date(birthDate);
  let age = today.getFullYear() - birth.getFullYear();
  const m = today.getMonth() - birth.getMonth();
  if (m < 0 || (m === 0 && today.getDate() < birth.getDate())) {
    age--;
  }
  return age;
};

const StudentForm: React.FC<StudentFormProps> = ({ onSave }) => {
  const { id } = useParams<{ id: string | undefined }>();
  const navigate = useNavigate();
  const [formData, setFormData] = useState<Student>({
    id: undefined,
    name: '',
    grade: 0,
    averageGrade: 0,
    address: '',
    birthDate: new Date(),    
    age: calculateAge(new Date()),
  });
  const [showLogout, setShowLogout] = useState(false); 
  const { token, logout } = useAuth();

  const handleCloseLogout = () => setShowLogout(false); 
  const handleShowLogout = () => setShowLogout(true); 

  useEffect(() => { 
    if (id) {
      studenGetService(id)
        .then(response => {
          const studentData = {
            ...response,
            birthDate: new Date(response.birthDate)
          };
          studentData.age = calculateAge(studentData.birthDate);
          setFormData(studentData);
        })
        .catch(error => {
          console.error('Falha listar estudantes.', error);
          toast.error('Falha listar estudantes.');
          navigate('/students');
        });
    } 
  }, [id, navigate]);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value, type } = event.target;
    if (type === 'date') {
      const newBirthDate = new Date(value);
      setFormData({
        ...formData,
        birthDate: newBirthDate,
        age: calculateAge(newBirthDate)
      });
    } else {
      setFormData({ ...formData, [name]: value as any });
    }
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    //forma eficiente antes do service
    // const method = id ? 'put' : 'post';
    // const url = id ? `/Students/${id}` : '/Students';
    // axiosClient[method](url, formData);

    try {
      const response = id ?  await studentUpdateService(id,formData) : await studentAddService(formData); 
      const message = response.message || `Estudante ${id ? 'atualizado' : 'adicionado'} com sucesso!`;      
      toast.success(message);
      setTimeout(() => {
        onSave(formData, navigate);
      }, 2000);
    } catch (error: any) {
      console.error(`Falha ao ${id ? 'atualizar' : 'adicionar'} estudante`, error);
      toast.error(`Falha ao ${id ? 'atualizar' : 'adicionar'} estudante: ${error.response?.data?.message || 'Server error'}`);
    }
  };

  const handleLogoutConfirm = () => {
    logout();
    navigate('/');
    handleCloseLogout();
  };

  return (
    <Container className="mt-3">
      <Row className="mb-3">
        <Col>
          <h2>{id ? 'Atualizar' : 'Adicionar'} Estudante</h2>
        </Col>
        <Col className="text-right">
          <Button variant="primary" onClick={() => navigate('/students')}>Lista de Estudantes</Button>
          <Button variant="secondary" onClick={handleShowLogout} className="ms-2">Sair</Button>
        </Col>
      </Row>
      <Row className="justify-content-md-center">
        <Col xs={12} md={8}>
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3">
              <Form.Label>Nome</Form.Label>
              <Form.Control
                type="text"
                name="name"
                value={formData.name}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Nome do Pai</Form.Label>
              <Form.Control
                type="text"
                name="fatherName"
                value={formData.fatherName}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Nome da Mae</Form.Label>
              <Form.Control
                type="text"
                name="motherName"
                value={formData.motherName}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Data de nascimento</Form.Label>
              <Form.Control type="date" name="birthDate" value={formData.birthDate.toISOString().substring(0, 10)} onChange={handleChange} />
            </Form.Group>            
            <Form.Group className="mb-3">
              <Form.Label>Idade</Form.Label>
              <Form.Control
                type="number"
                name="age"
                value={formData.age || ''}
                onChange={handleChange}
                disabled 
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Série</Form.Label>
              <Form.Control
                type="number"
                name="grade"
                value={formData.grade || ''}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Nota Média</Form.Label>
              <Form.Control
                type="number"
                name="averageGrade"
                value={formData.averageGrade || ''}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Endereço</Form.Label>
              <Form.Control
                type="text"
                name="address"
                value={formData.address || ''}
                onChange={handleChange}
              />
            </Form.Group>
            <Button variant="primary" type="submit">{id ? 'Atualizar' : 'Adicionar'} Estudante</Button>
          </Form>
        </Col>
      </Row>
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

export default StudentForm;