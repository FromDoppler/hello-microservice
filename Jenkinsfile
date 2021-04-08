pipeline {
    agent any
    stages {
        stage('Verify Format') {
            steps {
                sh 'docker build --target verify-format .'
            }
        }
        stage('Verify .sh files') {
            steps {
                sh 'docker build --target verify-sh .'
            }
        }
    }
}
