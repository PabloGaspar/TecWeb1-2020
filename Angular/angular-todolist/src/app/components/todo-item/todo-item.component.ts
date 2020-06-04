import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Todo } from 'src/app/models/Todo';
import { TodoService } from 'src/app/services/todo.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent implements OnInit {

  @Input() todoInput: Todo;
  @Output() todoDeleteOutput: EventEmitter<Todo> = new EventEmitter();


  constructor(private todoService:TodoService,  private route: ActivatedRoute,
    private router: Router) { }

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
    this.todoDeleteOutput.emit(this.todoInput);
  }

  onChange(){
    this.todoInput.completed =  !this.todoInput.completed;
    this.todoService.updateTodo(this.todoInput).subscribe( todo => {
      console.log(todo);
    });
  }

  onEdit() {
    console.log('redirect');
    this.router.navigateByUrl(`/todos/${this.todoInput.id}`);
    //this.router.navigate(['/todos', { todoId: this.todoInput.id }]);
  }
}
