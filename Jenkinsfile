/***************************************************
*  Author:  Adam Kuyrkendall        
*
*       Reference:
*   Jenkins Pipeline Syntax:  https://jenkins.io/doc/book/pipeline/syntax/
****************************************************/

pipeline {
    environment {
        /********************************************************************************** 
        *       BUILD PIPELINE VARIABLES:
        *       CONTAINER_TEMPLATE_NAME OPTIONS: ['dotnet-lambda-build']
        *       CONTAINER_TEMPLATE_IMAGE OPTIONS: ['uship/dotnet2.0_build_agent:1.06']
        *       SLACK_SEND_CHANNEL OPTIONS: ['#build_payments']
        *       SERVICE_LANGUAGE OPTIONS = ['node', 'net', 'python']    
        ***********************************************************************************/
        CONTAINER_TEMPLATE_NAME = 'dotnet-lambda-build'
        CONTAINER_TEMPLATE_IMAGE = 'uship/dotnet2.0_build_agent:1.06'
        SLACK_SEND_CHANNEL = '#wheresmycup'
        // TODO: move this branch back to master
        GIT_BRANCH = 'Master'
        GIT_URL = 'https://github.com/michaelrivet/StockApi.git'
        GIT_CREDENTIALS_ID = '1'
        SERVICE_NAME = 'mike_test'
        SERVICE_LANGUAGE = 'C#'
        SERVICE_LANGUAGE_VERSION = '7'
    }

    agent {
        any {
            label 'dotnet'
            containerTemplate {
                name "${env.CONTAINER_TEMPLATE_NAME}"
                image "${env.CONTAINER_TEMPLATE_IMAGE}"
                ttyEnabled true
            }
        }
    }
    stages {
        stage('DEV: Echoing Stage Environment Variables') {
            steps {
                echo "[INFO] CONTAINER_TEMPLATE_NAME: ${env.CONTAINER_TEMPLATE_NAME}"
                echo "[INFO] CONTAINER_TEMPLATE_IMAGE: ${env.CONTAINER_TEMPLATE_IMAGE}"
                echo "[INFO] SLACK_SEND_CHANNEL: ${env.SLACK_SEND_CHANNEL}"
                echo "[INFO] GIT_URL: ${env.GIT_URL}"
                echo "[INFO] GIT_BRANCH: ${env.GIT_BRANCH}" 
                echo "[INFO] SERVICE_NAME: ${env.SERVICE_NAME}"
                echo "[INFO] SERVICE_LANGUAGE: ${env.SERVICE_LANGUAGE}"
                echo "[INFO] SERVICE_LANGUAGE_VERSION: ${env.SERVICE_LANGUAGE_VERSION}"
            }  
        }

        stage('DEV: Notify Start') {
            steps {
                slackSend channel: "${env.SLACK_SEND_CHANNEL}",
                          message: "STARTED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' (${env.BUILD_URL})" 
            }
        }

        stage('DEV: Source Control Setup') {
            steps {
                container("${env.CONTAINER_TEMPLATE_NAME}") {
                    git branch: "${env.GIT_BRANCH}",  
                        credentialsId: "${env.GIT_CREDENTIALS_ID}",
                        url: "${env.GIT_URL}"
                }
            }  
        }

        stage('DEV: Environment Runtime Setup') {
            steps {
                container("${env.CONTAINER_TEMPLATE_NAME}") {
                    echo "Entering Environment Runtime Setup for ${env.SERVICE_LANGUAGE}"

                    script {
                        switch (env.SERVICE_LANGUAGE) {
                            case 'node':
                                // TODO: implement node base installation, assuming bare metal container
                                sh 'npm install'
                                sh 'node -v'
                                break
                            case 'python':
                                // TODO: implement environment setup for python
                                break
                            case 'net':
                                // TODO: implement environment setup for net
                                break
                            default:
                                throw new Exception("Invalid argument for SERVICE_LANGUAGE specified.  Failing build.")
                                break
                        }
                    }
                }
            }
        }

        /***************************************************************************
        *  PAYPAL
        ***************************************************************************/
        
        stage("DEV: Unit Testing Paypal") {
            steps {
                container("${env.CONTAINER_TEMPLATE_NAME}") {
                    script {
                        switch (env.SERVICE_LANGUAGE) {
                            case 'node':
                                sh 'npm run test:unit'
                                break
                            case 'python':
                                // TODO: implement test runner for python
                                break
                            case 'net':
                                // TODO: implement test runner for net
                                break
                            default:
                                throw new Exception("Invalid argument for SERVICE_LANGUAGE specified.  Failing build.")
                                break
                        }
                    }
                }
            }
        }

        /*
        stage("DEV: Deploy Primary Region - ${env.SERVICE_NAME}") {
            steps {
                container("${env.CONTAINER_TEMPLATE_NAME}") {
                    dir ('./paypal') {
                        // TODO: implement selector for blue\green stage
                        sh 'serverless deploy -v --stage dev --region us-east-1'
                    }
                }
            }  
        }

        stage("DEV: End to End Tests (Primary Region) - ${env.SERVICE_NAME}") {
            steps {
                // TODO: implement end to end test runner for us-east-1
                sh 'ls -la'
            }
        }

        stage("DEV: Deploy Secondary Region - ${env.SERVICE_NAME}") {
            steps {
                container("${env.CONTAINER_TEMPLATE_NAME}") {
                    dir ('./paypal') {
                        // TODO: implement selector for blue\green stage
                        sh 'serverless deploy -v --stage dev --region us-west-2'
                    }
                }
            }
        }
        */
    }
    post {
        success {
          slackSend channel: "${env.SLACK_SEND_CHANNEL}", 
                    color: '#00FF00', 
                    message: "SUCCESSFUL: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' (${env.BUILD_URL})"
        }

        failure {
          slackSend channel: "${env.SLACK_SEND_CHANNEL}", 
                    color: '#FF0000', 
                    message: "FAILED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' (${env.BUILD_URL})"

          emailext (
              subject: "FAILED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
              body: """<p>FAILED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]':</p>
                <p>Check console output at &QUOT;<a href='${env.BUILD_URL}'>${env.JOB_NAME} [${env.BUILD_NUMBER}]</a>&QUOT;</p>""",
              recipientProviders: [[$class: 'DevelopersRecipientProvider']]
            )
        }
    }

    // TODO: Implement container cleanup
}