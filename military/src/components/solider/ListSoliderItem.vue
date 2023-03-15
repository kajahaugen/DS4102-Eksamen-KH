<template>
   
        <tbody>
            <tr>
                <th scope="row">{{id}}</th>
                <td>{{firstName}}</td>
                <td>{{lastName}}</td>
                <td>{{birthdate}}</td>
                <td>{{grade}}</td>
                <td>{{ranking}}</td>
            </tr>
        </tbody>
        
</template>

<script>
export default {
    props: {
        id: Number,
        firstName: String, 
        lastName: String, 
        birthdate: String, 
        grade: String, 
        ranking: String, 
    },
}
</script>