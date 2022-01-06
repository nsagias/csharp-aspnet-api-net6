import React, { useState } from "react";

const todosList = [
  {id:1, name: "react with C#", description: "combine react with c#"},
  {id:2, name: "react with secure endpoitns", description: "secure this later"}
];

export default function TodoItem({ todo }) {
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
      <div>
        <h3>
          <input 
            onChange={ event => updateHandler(event.target.value, 'name', data)} 
            value={data.name} 
          />
        </h3>
        <div>
          <input 
            onChange={ event => updateHandler(event.target.value, 'description', data)} 
            value={data.description} 
          />
        </div>
        {isDoing ? 
          <div><button onClick={onSave}>Save</button></div> : null
        }
      </div>
    </>
  );
}