import React from 'react';
import Menu from '../../components/menu';
import Rodape from '../../components/rodape';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Carousel, Jumbotron, Button, Container, Row, Col,Card} from 'react-bootstrap';

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
            <Container>
                <Row>
                    <Col>
                        <Card style={{ width : '18rem' }}>
                            <Card.Img variant="top" src="https://educador360.com/wp-content/uploads/2018/05/tipos-de-alunos-thumb-recuperado.jpg"></Card.Img>
                            <Card.Body>
                                <Card.Title>Inovação</Card.Title>
                                <Card.Text>
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Cupiditate, quos? Eaque, cum illum impedit pariatur iure temporibu
                                </Card.Text>
                                <Button variant="primary">Go somewhere</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col>
                        <Card style={{ width : '18rem' }}>
                            <Card.Img variant="top" src="https://educador360.com/wp-content/uploads/2018/05/tipos-de-alunos-thumb-recuperado.jpg"></Card.Img>
                            <Card.Body>
                                <Card.Title>Educação</Card.Title>
                                <Card.Text>
                                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Cupiditate, quos? Eaque, cum illum impedit pariatur iure temporibu
                                </Card.Text>
                                <Button variant="primary">Go somewhere</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col>
                        <Card style={{ width : '18rem' }}>
                            <Card.Img variant="top" src="https://educador360.com/wp-content/uploads/2018/05/tipos-de-alunos-thumb-recuperado.jpg"></Card.Img>
                            <Card.Body>
                                <Card.Title>Desenvolvimento</Card.Title>
                                <Card.Text>
                                    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Cupiditate, quos? Eaque, cum illum impedit pariatur iure temporibu
                                </Card.Text>
                                <Button variant="primary">Go somewhere</Button>
                            </Card.Body>
                        </Card>
                     </Col>
                </Row>
            </Container>

            <Rodape />
        </div>
    )
}

export default Home