import React from 'react';
import Menu from '../../components/menu';
import Rodape from '../../components/rodape';
import {Container, Form, Button} from 'react-bootstrap';
import logo from '../../assets/img/Logo.svg';
import './index.css';

const Login = () => {
    return (
        <div>
            <Menu />
                <Container className='form-height'>
                    <Form className='form-signin'>
                        <div className='text-center'>
                            <img  alt="NYOUS" src={logo} style={{ width : '64px' }}/>
                        </div>
                        <br/>
                        <small>Informe os dados abaixo</small>
                        <hr/>
                        <Form.Group controlId='formBasicEmail' >
                            <Form.Label>Email</Form.Label>
                            <Form.Control type='email' placeholder='Digite o seu email' ></Form.Control>
                        </Form.Group>
                        <Form.Group controlId='formBasicPassword' >
                            <Form.Label>Senha</Form.Label>
                            <Form.Control type='password' placeholder='Digite a sua senha' required ></Form.Control>
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
