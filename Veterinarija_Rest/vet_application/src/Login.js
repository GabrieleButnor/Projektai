import React, {Component} from "react";
import {Modal,Button,Row,Col, Form, FormGroup} from "react-bootstrap"


export class Login extends Component
{
    constructor(props)
    {
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event)
    {
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'login',
        {
            method:'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                e_mail:event.target.e_mail.value,
                password:event.target.password.value
            })
        })
        .then(response=>response.json())
        .then((result)=>{
            console.log(result)
            localStorage.setItem('token', result.accessToken);
            localStorage.setItem('id', result.id);
            alert(result);
        },
        (error)=>{
            alert('Napavyko sukurti.')
        })
    }


    render()
    {

        return(

            <div className="containe ">
                <h3 className="mt-5 d-flex">
                Prisijungimo forma
                </h3>
            <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="code">
                        <Form.Label>Elektroninis paštas</Form.Label>
                        <Form.Control type="email" name="e_mail" required placeholder="pastas@pastas.com"/>
                    </Form.Group>
                    <Form.Group controlId="type">
                        <Form.Label>Slaptažodis</Form.Label>
                        <Form.Control type="password" name="password" required placeholder="slaptazodis"/>
                    </Form.Group>
                    
                    <Form.Group>
                        <Button variant="primary" type="submit" style={{ marginTop:15}}>
                            Prisijungti
                         </Button>
                     </Form.Group>
                    
                    </Form>
                </Col>
                </Row>
                </div>

        )
    }
}



