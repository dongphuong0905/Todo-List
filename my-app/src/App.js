import logo from './logo.svg';
import './App.css';
import React, { Component } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';

class App extends Component {
  state = { todo: [] };
  async componentDidMount() {
    let result = await axios.get("https://localhost:44309/todo");
    console.log(result);
    this.setState({ todo: result.data });
  }
  render() {
    return (
      <div className="container">
        <div>
          <h1 align="center">TODO LIST</h1>
        </div>
        {this.state.todo.length > 0 ? (
          <div>
            <ul class="list-group">
              {this.state.todo.map((todo) =>
                <li key={todo.todoID} class="list-group-item d-flex justify-content-between align-items-center">
                  {todo.todoValue}
                  {todo.todoStatus === "1" ? (
                    <span class="badge badge-danger badge-pill">Not doing</span>
                  ) : (todo.todoStatus === "2" ? (
                    <span class="badge badge-primary badge-pill">Doing</span>
                  ) : todo.todoStatus === "3" ? (
                    <span class="badge badge-success badge-pill">Done</span>
                  ) : <div></div>)}

                </li>
              )}
            </ul>
          </div>
        ) : (<div className="spinner-border text-primary" role="status">
          <span className="sr-only">Loading.....</span>
        </div>)}

      </div>
    );
  }

}

export default App;
