import React, {Component} from "react";
import {Table} from "react-bootstrap";
import { Button, ButtonToolbar } from "react-bootstrap";

export class User extends Component
{

    constructor(props)
    {
        super(props);
        this.state={usr:[]};
    }

    refrechList()
    {
        fetch(process.env.REACT_APP_API+'users',
        {
            method:'GET',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type':'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            }
        })
        .then(response=>response.json())
        .then(data=>{
            this.setState({usr:data})
        });
    }

    componentDidMount()
    {
        this.refrechList();
    }

    componentDidUpdate()
    {
        this.refrechList();
    }

    render()
    {
        const {usr}=this.state;
        return(
            <div>
                <Table className="mt-8"  striped bordered hover size="sm">
                    <thead>
                    <div className="mt-5 p-2 d-flex justify-content-right">

                    </div>
                        <tr>
                            <th>Asmens kodas</th>
                            <th>Vardas</th>
                            <th>Pavardė</th>
                            <th>Elektroninis paštas</th>
                            <th>Telefono numeris</th>
                            <th>Adresas</th>
                        </tr>
                    </thead>
                    <tbody>
                        {usr.map(user=>
                            <tr key={user.id}>
                                <td>{user.personal_code}</td>
                                <td>{user.userName}</td>
                                <td>{user.surname}</td>
                                <td>{user.email}</td>
                                <td>{user.phoneNumber}</td>
                                <td>{user.address}</td>
                                <td style={{width: '360px'}} > 
                                    
                                    <ButtonToolbar>
                                        <Button variant="success" style={{ marginLeft: "auto"}}
                                        //  onClick={()=>this.setState({getModalShow:true, 
                                        //     sid:user.id, userName:sevice.code, stype:sevice.type, 
                                        //     sprice:sevice.price, sduration:sevice.duration, 
                                        //     sfk_UserId:sevice.fk_UserId })}
                                        >
                                             Peržiūrėti
                                        </Button>


                                        <Button variant="info" style={{ marginLeft: 20}}
                                        // onClick={()=>this.setState({editModalShow:true,
                                        //     sid:sevice.id, scode:sevice.code, stype:sevice.type, 
                                        //     sprice:sevice.price, sduration:sevice.duration
                                        //     })}
                                            >
                                                Redaguoti
                                        </Button>

                                        <Button  variant="danger" style={{ marginLeft: 20}}
                                        onClick={()=>this.deleteService(usr.id)}>
                                                Naikinti
                                        </Button>
{/* 
                                        <EditServiceModal show={this.state.editModalShow}
                                        onHide={editModalClose}
                                        sid={sid}
                                        scode={scode}
                                        stype={stype}
                                        sprice={sprice}
                                        sduration={sduration} > 
                                        </EditServiceModal> */}
{/* 
                                        <GetServiceModal show={this.state.getModalShow}
                                        onHide={getModalClose}
                                        sid={sid}
                                        scode={scode}
                                        stype={stype}
                                        sprice={sprice}
                                        sduration={sduration}
                                        sfk_UserId={sfk_UserId}> 
                                        </GetServiceModal>  */}
                                    </ButtonToolbar> 
                                    </td>
                            </tr>)}
                    </tbody>
                </Table>

            </div>
        )
    }
}