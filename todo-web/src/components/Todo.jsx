import React, { useState } from "react";
import { 
  TodoFrame, 
  Input, 
  Title, 
  Save 
} from "./TodoStyles";


const todosList = [
  {id:1, name: "react with C#", description: "combine react with c#"},
  {id:2, name: "react with secure endpoitns", description: "secure this later"}
];

function Todo({ todo }) {
  const [data, setData] = useState(todo);
  const [isDoing, setIsDoing] = useState(false);

  function updateHandler(value, fieldName, obj) {
    setData({ ...obj, [fieldName] : value});
  }

  function onSave() {
    setIsDoing(false);
  }


  return (
    <>
      <TodoFrame>
        <div>
          <h3>
            <Title input 
              onChange={ event => updateHandler(event.target.value, 'name', data)} 
              value={data.name} 
              />
          </h3>
          <div>
            <Input input 
              onChange={ event => updateHandler(event.target.value, 'description', data)} 
              value={data.description} 
              />
          </div>
          {isDoing ? 
            <div><Save onClick={onSave}>Save</Save></div> : null
          }
        </div>
      </TodoFrame>  
    </>
  );
}

export default function TodoList() {

  const parsedTodos = Array.isArray(todosList) 
    && todosList.map(todo => <Todo todo={todo} />);
  return (
    <>
      {parsedTodos}
    </>
  );
}