
import React, {Component} from "react";
import {Navigation} from './Navigation';

export class Home extends Component
{
    state = {};

    componentDidMount()
    {
        const config = {
            headers:{
                Authorization: 'Bearer ' + localStorage.getItem('token')
            }
        };
  
          fetch(process.env.REACT_APP_API+'users/'+localStorage.getItem('id'))
          .then(response=>response.json())
          .then((result)=>{
              localStorage.setItem('name', result.userName);
              localStorage.setItem('surname', result.surname);
              localStorage.setItem('type', result.type);
              this.setState({
                  user: result                
              });
          },
          (error)=>{
              console.log(error)
              alert('Nera.')
          })
    }

    render()
    {
        if(localStorage.getItem('name') != null)
        {   
            return(
            <h4 className="mt-5 d-flex justify-content-right">
                Pagrindinis puslapis prisijugusio vartotojo: {localStorage.getItem('name')} {localStorage.getItem('surname')} 
            </h4>
            )
        }
        return(
                <h4 className="mt-5 d-flex justify-content-right">
                    Pagrindinis puslapis neprisijugusio vartotojo.
                </h4>
            )
    }
}