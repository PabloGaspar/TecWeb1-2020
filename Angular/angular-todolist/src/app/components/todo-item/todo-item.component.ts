import { Component, OnInit, Input } from '@angular/core';
import { Todo } from 'src/app/models/Todo';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent implements OnInit {

  @Input() todoInput: Todo;
  constructor() { }

  ngOnInit() {
  }

  // set classes
  setClasses(){
    let clases = {
      todo: true,
      'is-complete': this.todoInput.completed
    }
    return clases;
  }

  onDelete(){
    console.log("deleted");
  }
}
