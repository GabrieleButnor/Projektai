import React, {Component} from "react";
import {Modal,Button,Row,Col, Form} from "react-bootstrap"
import ModalHeader from "react-bootstrap/esm/ModalHeader";

export class EditServiceModal extends Component
{
    constructor(props)
    {
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event)
    {
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'services/'+this.props.sid,
        {
            method:'PUT',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type':'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
                'Id': localStorage.getItem('id')
            },
            body: JSON.stringify({
                id:event.target.id.value,
                code:event.target.code.value,
                type:event.target.type.value,
                price:event.target.price.value,
                duration:event.target.duration.value
            })
        })
        .then(response=>response.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Napavyko atnaujinti.')
        })
    }


    render()
    {
        return (
            <div className="container">
                <Modal
                    {...this.props}
                    size="lg"
                    aria-labelledby="contaoned-modal-title-vcenter"
                    centered
                >
                    <ModalHeader closeButton>
                        <Modal.Title id="contaoned-modal-title-vcenter">
                            Atnaujinti paslaugą
                        </Modal.Title>
                    </ModalHeader>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="id">
                                        <Form.Label>Paslaugos id</Form.Label>
                                        <Form.Control type="number" name="id" required 
                                        disabled
                                        defaultValue={this.props.sid}/>
                                    </Form.Group>

                                    <Form.Group controlId="code">
                                        <Form.Label>Paslaugos kodas</Form.Label>
                                        <Form.Control type="text" name="code" required 
                                        defaultValue={this.props.scode} placeholder="kodas"/>
                                    </Form.Group>
                                    <Form.Group controlId="type">
                                        <Form.Label>Paslaugos tipas</Form.Label>
                                        <Form.Control type="text" name="type" required 
                                        defaultValue={this.props.stype} placeholder="tipas"/>
                                    </Form.Group>
                                    <Form.Group controlId="price">
                                        <Form.Label>Paslaugos kaina</Form.Label>
                                        <Form.Control type="number" step={0.01} min="0" name="price" required 
                                        defaultValue={this.props.sprice} placeholder="kaina"/>
                                    </Form.Group>
                                    <Form.Group controlId="duration">
                                        <Form.Label>Paslaugos trukmė</Form.Label>
                                        <Form.Control type="time" name="duration" required 
                                        defaultValue={this.props.sduration} placeholder="trukmė"/>
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit" style={{ marginTop:15}}>
                                            Atnaujinti paslaugą
                                        </Button>
                                    </Form.Group>

                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>
                            Uždaryti
                        </Button>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }


}