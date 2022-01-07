import styled from "styled-components";

export const TodoFrame = styled.div`
    border: solid 1px gray;
    padding: 10px;
    margin: 15px 10px;
    border-radius: 5px;
    box-shadow: 0 0 5px grey;
    font-family: Arial;
`;

export const Input = styled.input`
    border: solid 1px black;
    padding: 5px;
    border-radius: 3px;
`;

export const Title = styled(Input)`
    text-transform: uppercase;
`;

export const Save = styled.button`
   width: 100px;
   margin: 10px;
   background: #455A64;
   color: white;
   font-size: 16px;
   padding: 10px;
   border-radius: 5px;
`;