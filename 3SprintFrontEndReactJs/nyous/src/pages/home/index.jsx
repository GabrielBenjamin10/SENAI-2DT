import React from 'react';
import Menu from '../../components/menu';
import Rodape from '../../components/rodape';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Carousel, Jumbotron, Button} from 'react-bootstrap';

const Home = () => {
    return(
        <div>
            <Menu />

            <Carousel>
                <Carousel.Item>
                    <img
                    className='d-block w-100'
                    src='https://www.ilhabela.com.br/wp-content/uploads/2016/01/eventos-em-ilhabela.jpg'
                    alt='First slide'/>
                </Carousel.Item>
                <Carousel.Item>
                    <img
                    className='d-block w-100'
                    src='https://www.ilhabela.com.br/wp-content/uploads/2016/01/eventos-em-ilhabela.jpg'
                    alt='First slide'/>
                </Carousel.Item>
            </Carousel>

            <Jumbotron className="text-center">
                <h1>Diversos eventos em um unico local</h1>
                <p>Encontre eventos nos mais diversos segmentos de forma rápida</p>
                <p><Button variant="primary" href="/login">Login</Button><Button variant="btn btn-success" style={{marginLeft : '10px'}} href="/cadastrar">Cadastrar</Button></p>
            </Jumbotron>

            <Rodape />
        </div>
    )
}

export default Home