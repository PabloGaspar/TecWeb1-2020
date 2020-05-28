import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/Todo';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {

  todos:Todo[]
  constructor() { }

  ngOnInit() {
    this.todos = [
      {
        id: 1,
        title: "clean my room",
        completed : true
      },
      {
        id:2,
        title:"shop more videogames",
        completed: true
      },
      {
        id:3, 
        title: "Preare lunch",
        completed: false
      }
    ];
  }

}
