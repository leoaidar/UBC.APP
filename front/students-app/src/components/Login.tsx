import React, { useEffect, useState } from 'react';
import { Button, TextField, Box } from '@mui/material';
import axiosClient from '../utils/axiosClient';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import { useSnackbar } from 'notistack';  

interface LoginProps {}

const Login: React.FC<LoginProps> = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const { login } = useAuth();
  const navigate = useNavigate();
  const { enqueueSnackbar } = useSnackbar();
    
  useEffect(() => { 
    //Fixando login para facilitar entrada
    setUsername("David");
    setPassword("2013-07-18");
  }, []);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      const response = await axiosClient.post('/Auth/login', {
        username,
        password
      });
      if (response.data.token) {
        login(response.data.token);
        navigate('/students');
        enqueueSnackbar('Login com sucesso!', { variant: 'success' }); 
      }
    } catch (error: any) {  
      console.error('Login falhou:', error);
      const errorMessage = error.response?.data?.message || 'Request Error';
      enqueueSnackbar('Login falhou: ' + errorMessage, { variant: 'error' });
    }
  };

  return (
      <Box component="form" onSubmit={handleSubmit} sx={{ display: 'flex', flexDirection: 'column', gap: 2, maxWidth: 350, margin: 'auto', padding: '50px'}}>
        <h2>Estudantes App</h2>
        <TextField label="Usuario" value={username} onChange={(e) => setUsername(e.target.value)} />
        <TextField label="Senha" type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        <Button type="submit" variant="contained" color="primary">Entrar</Button>
      </Box>
  );
};

export default Login;