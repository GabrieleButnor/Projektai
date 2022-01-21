import React, {Component} from "react";
import {Table} from "react-bootstrap";

import { Button, ButtonToolbar } from "react-bootstrap";
// import {AddServiceModal} from './AddServiceModal';
// import {EditServiceModal} from './EditServiceModal';
// import {GetServiceModal} from './GetServiceModal';

export class Pet extends Component
{
    
    constructor(props)
    {
        super(props);
        this.state={serv:[], addModalShow:false, editModalShow:false, getModalShow:false};
    }


    refrechList()
    {
    
        fetch(process.env.REACT_APP_API+'users/'+localStorage.getItem('id')+'/pets',
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
            this.setState({serv:data})
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

    deleteService(sid)
    {
        if(window.confirm('Ar tikrai norite pašalinti?'))
        {
            fetch(process.env.REACT_APP_API+'users/'+localStorage.getItem('id')+'/pets'+sid,
            {
                method:'DELETE',
                headers:
                {
                    'Accept': 'application/json',
                    'Content-Type':'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem('token'),

                }
            })
            .then(response=>response.json())
            .then((result)=>{
                alert(result);
            },
            (error)=>{
                alert('Pašalinti negalima .')
            })
        }
    }

    render()
    {
        const {serv, sid, schip, sspecies, stype, sname, sdata, sfk_UserId}=this.state;
        let editModalClose=()=>this.setState({editModalShow:false});
        let addModalClose=()=>this.setState({addModalShow:false});
        let getModalClose=()=>this.setState({getModalShow:false});
        return(
            <div>
                <ButtonToolbar>
                    <Button variant='primary' style={{ marginLeft: "auto", marginTop:15, marginBottom:15}}
                    onClick={()=> this.setState({addModalShow:true})}>                
                    Pridėti naują gūvūną.
                    </Button>
{/* 
                    <AddServiceModal show={this.state.addModalShow}
                    onHide={addModalClose}></AddServiceModal> */}
                </ButtonToolbar>

                <Table className="mt-8" background-color="white" striped bordered hover size="sm">
                    <thead>
                    {/* <div className="mt-3 d-flex justify-content-right">
                        Paslagų sąrašas
                    </div> */}
                        <tr>
                            <th>Id</th>
                            <th>Čipsas</th>
                            <th>Rūšis</th>
                            <th>Tipas</th>
                            <th>Vardas</th>
                            <th>Data</th>
                        </tr>
                    </thead>
                    <tbody>
                        {serv.map(sevice=>
                            <tr key={sevice.id}>
                                <td>{sevice.id}</td>
                                <td>{sevice.chip}</td>
                                <td>{sevice.species}</td>
                                <td>{sevice.type}</td>
                                <td>{sevice.name}</td>
                                <td>{sevice.date}</td>
                                <td style={{width: '360px'}} > 
                                    
                                    <ButtonToolbar>
                                        <Button variant="success" style={{ marginLeft: "auto"}}
                                        //  onClick={()=>this.setState({getModalShow:true, 
                                        //     sid:sevice.id, scode:sevice.code, stype:sevice.type, 
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
                                        onClick={()=>this.deleteService(sevice.id)}>
                                                Naikinti
                                        </Button>

                                        {/* <EditServiceModal show={this.state.editModalShow}
                                        onHide={editModalClose}
                                        sid={sid}
                                        scode={scode}
                                        stype={stype}
                                        sprice={sprice}
                                        sduration={sduration} > 
                                        </EditServiceModal>

                                        <GetServiceModal show={this.state.getModalShow}
                                        onHide={getModalClose}
                                        sid={sid}
                                        scode={scode}
                                        stype={stype}
                                        sprice={sprice}
                                        sduration={sduration}
                                        sfk_UserId={sfk_UserId}> 
                                        </GetServiceModal> */}
                                    </ButtonToolbar>
                                    
                                </td>
                            </tr>)}
                    </tbody>
                </Table>

            </div>
        )
    }
}
