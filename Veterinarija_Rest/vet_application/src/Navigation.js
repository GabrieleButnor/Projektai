import React, {Component} from "react";
import {Link, NavLink} from "react-router-dom";
import{Navbar, Nav} from "react-bootstrap";

export class Navigation extends Component
{
    constructor(props)
    {
        super(props);
    }

    render()
    {
        if(localStorage.getItem('type') == '9' || localStorage.getItem('type') == 9)
        {
            return(
            //     <Navbar bg="dark" expand="lg">
            //     <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            //     <Navbar.Collapse id="basic-navbar-nav">
            //         <Nav className="ml-auto">
            //             <NavLink className="d-inline  p-2 bg-dark text-white" to="/">
            //                 Pagrindinis puslapis
            //             </NavLink>   
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/user">
            //                 Klientai
            //             </NavLink> 
            //             <NavLink  className="d-inline p-2 bg-dark text-white" onClick={localStorage.clear()} to="/">
            //                 Atsijungti
            //             </NavLink>            
            //         </Nav>
            //     </Navbar.Collapse>     
            // </Navbar>
            // )

                            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">
                        <NavLink className="d-inline  p-2 bg-dark text-white" to="/">
                            Pagrindinis puslapis
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/user">
                            Klientai
                        </NavLink>                       
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/pet">
                            Augintiniai
                        </NavLink>               
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/service">
                            Paslaugos
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/visit">
                            Vizitai
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                            Prisijungti
                        </NavLink> 
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/singup">
                            Registruotis
                        </NavLink>   
                        <NavLink className="d-inline p-2 bg-dark text-white" onClick={localStorage.clear()} to="/">
                            Atsijunti
                        </NavLink>  
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                        Prisijungti
                    </NavLink>                   
                    </Nav>
                </Navbar.Collapse>     
            </Navbar>
            )
        }
        
        if(localStorage.getItem('type') == '5'|| localStorage.getItem('type') == 5)
        {
            return(
                <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">
                        <NavLink className="d-inline  p-2 bg-dark text-white" to="/">
                            Pagrindinis puslapis
                        </NavLink>   
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/user">
                            Klientai
                        </NavLink>                       
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/pet">
                            Augintiniai
                        </NavLink>               
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/service">
                            Paslaugos
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/visit">
                            Vizitai
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/" onClick={localStorage.clear()} >
                            Atsijungti
                        </NavLink>     
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                        Prisijungti
                    </NavLink>                                                     
                    </Nav>
                </Navbar.Collapse>     
            </Navbar>
            )
        }

        if(localStorage.getItem('type') == '1'|| localStorage.getItem('type') == 1)
        {
            return(
                <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">
                        <NavLink className="d-inline  p-2 bg-dark text-white" to="/">
                            Pagrindinis puslapis
                        </NavLink>  
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/pet">
                            Augintiniai
                        </NavLink>                            
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/visit">
                            Vizitai
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" onClick={localStorage.clear()} to="/">
                            Atsijunti
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                        Prisijungti
                    </NavLink>                
                    </Nav>
                </Navbar.Collapse>     
            </Navbar>
            )
        }
        if(localStorage.getItem('name') == null)
        {
            // return( 
            //     <Navbar bg="dark" expand="lg">
            //     <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            //     <Navbar.Collapse id="basic-navbar-nav">
            //         <Nav className="ml-auto">
            //             <NavLink className="d-inline  p-2 bg-dark text-white" to="/">
            //                 Pagrindinis puslapis
            //             </NavLink>
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/user">
            //                 Klientai
            //             </NavLink>                       
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/pet">
            //                 Augintiniai
            //             </NavLink>               
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/service">
            //                 Paslaugos
            //             </NavLink>
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/visit">
            //                 Vizitai
            //             </NavLink>
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
            //                 Prisijungti
            //             </NavLink> 
            //             <NavLink className="d-inline p-2 bg-dark text-white" to="/singup">
            //                 Registruotis
            //             </NavLink>   
            //             <NavLink className="d-inline p-2 bg-dark text-white" onClick={localStorage.clear()} to="/">
            //                 Atsijunti
            //             </NavLink>                
            //         </Nav>
            //     </Navbar.Collapse>     
            // </Navbar>
            // )
        // }

        return( 
            <Navbar bg="dark" expand="lg">
            <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="ml-auto">
                    <NavLink className="d-inline  p-2 bg-dark text-white" to="/">
                        Pagrindinis puslapis
                    </NavLink>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                        Prisijungti
                    </NavLink> 
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/singup">
                        Registruotis
                    </NavLink>                
                </Nav>
            </Navbar.Collapse>     
        </Navbar>
        )
        }
    }
}





















               

