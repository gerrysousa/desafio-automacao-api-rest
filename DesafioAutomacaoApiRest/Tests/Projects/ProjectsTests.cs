﻿using DesafioAutomacaoApiRest.Bases;
using DesafioAutomacaoApiRest.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DesafioAutomacaoApiRest.Pages;
using DesafioAutomacaoApiRest.Requests.Projects;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoApiRest.Tests.Projects
{
    class ProjectsTests : TestBase
    {
        [Test]
        public void Test_CadastrarUmProjetoComSucesso()
        {
            #region Parameters
            CreateAProjectRequest createAProjectRequest = new CreateAProjectRequest();
            Project project = new Project();
            Status status = new Status();
            ViewState viewState = new ViewState();

            string statusEsperado = "Created";//201

            int projectId = 1;
            string projectName = "Projeto test api 01";
            string projectDescription = "Mantis.  Report problems with the actual bug tracker here. (Do not remove this account)";
            bool projectEnabled = true;
            string projectFilePath = "/tmp/";

            int statusId = 10;
            string statusName = "development";
            string statusLabel = "development";

            int viewStateId = 10;
            string viewStateName = "public";
            string viewStateLabel = "public";

            #region json format
            /*
             {
               "id": 1,
               "name": "_new2",
               "status": {
                  "id": 10,
                  "name": "development",
                  "label": "development"
                },
                "description": "Mantis.  Report problems with the actual bug tracker here. (Do not remove this account)",
                "enabled": true,
                "file_path": "/tmp/",
                "view_state": {
                  "id": 10,
                  "name": "public",
                  "label": "public"
                }
            }
             */
            #endregion

            #endregion

            #region Acoes

            status.id = statusId;
            status.name = statusName;
            status.label = statusLabel;

            viewState.id = viewStateId;
            viewState.name = viewStateName;
            viewState.label = viewStateLabel;

            //montando body
            project.id = projectId;
            project.name = projectName;
            project.description = projectDescription;
            project.enabled = projectEnabled;
            project.file_path = projectFilePath;
            project.status = status;
            project.view_state = viewState;

            createAProjectRequest.SetJsonBody(project);

            IRestResponse<dynamic> response = createAProjectRequest.ExecuteRequest();
            #endregion

            #region Asserts

            #region json result
            /*
             {
                "project": {
                    "id": 2,
                    "name": "_new2",
                    "status": {
                        "id": 10,
                        "name": "development",
                        "label": "development"
                    },
                    "description": "Mantis.  Report problems with the actual bug tracker here. (Do not remove this account)",
                    "enabled": true,
                    "view_state": {
                        "id": 10,
                        "name": "public",
                        "label": "public"
                    },
                    "access_level": {
                        "id": 90,
                        "name": "administrator",
                        "label": "administrator"
                    },
                    "custom_fields": [],
                    "versions": [],
                    "categories": [
                        {
                            "id": 1,
                            "name": "General",
                            "project": {
                                "id": 0,
                                "name": null
                            }
                        }
                    ]
                }
            }
             */
            #endregion


            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusEsperado, response.StatusCode.ToString());
                Assert.AreEqual(projectName, response.Data.project.name.ToString());
                Assert.AreEqual(projectDescription, response.Data.project.description.ToString());
                //Etc
            });

            #endregion
        }
    }
}
