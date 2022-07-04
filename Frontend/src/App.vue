<template>
    <center>
        <div class="input-form" style="margin-top: 50px;">
            <form id="inputForm" @submit.prevent="onFormSubmit">
                <table cellspacing="7">
                    <tr>
                        <td>First name</td>
                        <td><input type="text" id="firstName" size="50" maxlength="50" required></td>
                    </tr>
                    <tr>
                        <td>Last name</td>
                        <td><input type="text" id="lastName" size="50" maxlength="50" required></td>
                    </tr>
                    <tr>
                        <td>Date of birth</td>
                        <td><input type="date" id="birthDate" style="width:320px;" required></td>
                    </tr>
                </table>
                <div style="margin-bottom: 10px; margin-left: -200px;">
                    <input type="file" id="file" required>
                </div>
                <br />
                <button type="submit" style="width: 425px;">Submit</button>
            </form>
        </div>
    </center>
</template>

<script>
    import axios from 'axios';

    export default {

        methods: {
            onFormSubmit() {
                let postData = new FormData();
                postData.append("firstName", document.getElementById('firstName').value);
                postData.append("lastName", document.getElementById('lastName').value);
                postData.append("birthDate", new Date(document.getElementById('birthDate').value).getTime());
                let docFile = document.querySelector('#file');
                postData.append('file', docFile.files[0]);
                const headers = "{ 'Content-Type': 'multipart/form-data' }";
                axios.post('http://localhost:5107/certificates', postData, { headers })
                    .then(response => { if (response.status == 200) { alert('Successfully submitted'); location.reload() } else { alert('An error has occurred') } })
                    .catch(error => { alert('An error has occurred'); console.log(error) });
            }
        }
    }
</script>