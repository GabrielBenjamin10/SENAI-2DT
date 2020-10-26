import React, { useState }  from 'react';
import { useHistory } from "react-router-dom";
import Menu from '../../components/menu';
import Rodape from '../../components/rodape';
import {Container, Form, Button} from 'react-bootstrap';
import logo from '../../assets/img/Logo.svg';
import './index.css';
import jwt_decode from 'jwt-decode';


const Login = () => {

    const history = useHistory();

    //Usando Hooks
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const logar = (event) => {
        event.preventDefault();
        
        fetch('http://localhost:5000/api/account/login', {
            method : 'POST',
            body : JSON.stringify({
                email : email,
                senha : senha
            }),
            headers :{

                'content-type' : 'application/json'
            }
        })
        .then(response => {

            if(response.ok){
                return response.json()

            }else{
                alert('dados inválidos');
            }

            console.log(response);
        })
        .then(data => {
            localStorage.setItem('tokenNyous', data.token);

            let usuario = jwt_decode(data.token);

            if(usuario.role === 'Admin'){
                history.push('/admin/dashboard');
            }else{
                history.push('/eventos');
            }

            history.push('/eventos');
        })
        .catch(err => console.error(err));

        console.log(`${email} - ${senha}`);
    }

    return (
        <div>
            <Menu />
                <Container className='form-height'>
                    <Form className='form-signin' onSubmit={event => logar(event)} >
                        <div className='text-center'>
                            <img  alt="NYOUS" src={logo} style={{ width : '64px' }}/>
                        </div>
                        <br/>
                        <small>Informe os dados abaixo</small>
                        <hr/>
                        <Form.Group controlId='formBasicEmail' >
                            <Form.Label>Email</Form.Label>
                            <Form.Control type='email' value={email} onChange={ event => setEmail(event.target.value)} placeholder='Digite o seu email' ></Form.Control>
                        </Form.Group>
                        <Form.Group controlId='formBasicPassword' >
                            <Form.Label>Senha</Form.Label>
                            <Form.Control type='password' value={senha} onChange={ event => setSenha(event.target.value)} placeholder='Digite a sua senha' required ></Form.Control>
                        </Form.Group>
                        <Button variant='primary' type='submit' >Enviar</Button>
                        <br/>
                        <a href="/cadastrar" style={{ marginTop : '30px'}}>Não tenho uma conta!</a>
                    </Form>
                </Container>
            <Rodape />
        </div>
    )
}

export default Login
