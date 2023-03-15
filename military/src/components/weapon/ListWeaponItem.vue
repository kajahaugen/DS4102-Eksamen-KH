<template>
   
        <tbody>
            <tr>
                <th scope="row">{{id}}</th>
                <td>{{name}}</td>
                <td>{{type}}</td>
                <td>{{magazinSize}}</td>
            </tr>
        </tbody>
        
</template>

<script>
export default {
    props: {
        id: Number,
        name: String, 
        type: String, 
        magazinSize: Number, 
    },
    
}
</script>