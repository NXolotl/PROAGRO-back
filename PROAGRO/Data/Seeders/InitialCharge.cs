using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PROAGRO.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROAGRO.Data.Seeders
{
    public class InitialCharge
    {
        public static void Initialize(Context context)
        {
            //Valida si la base de datos ya existe
            if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                context.Database.EnsureCreated();
            }

            //Valida si la tabla usuarios esta vacia
            if (!context.Usuarios.Any())
            {
                List<Usuarios> usuarios = new List<Usuarios>() {
                    new Usuarios { Id = Guid.Parse("96558290-a55c-4f64-9398-2672413761c0"), Nombre ="PORCICULTORES EL HIBRIDO S DE RL", FechaNacimiento = DateTime.Parse("11/01/2005"), RFC = "PHI0501116U3" },
                    new Usuarios { Id = Guid.Parse("cac88536-95e3-44a1-afab-76dab7eee076"), Nombre ="AGROPECUARIA EL GIGANTE S.A. DE C.V.", FechaNacimiento = DateTime.Parse("14/01/2000"), RFC ="AGI000114C70" },
                    new Usuarios { Id = Guid.Parse("a8e53288-a4df-4148-9219-96429976cb0c"), Nombre ="PROVEEDORES AGROALIMENTARIOS DEL DISTRITO DE RIEGO 01 SPR DE RL", FechaNacimiento = DateTime.Parse("28/05/2004 "), RFC ="PAD0405282B1" },
                    new Usuarios { Id = Guid.Parse("5ec13072-206b-4f91-bb47-4a0a61e36b2b"), Nombre ="EL SILOGISMO SPR DE RL", FechaNacimiento = DateTime.Parse("06/11/1997"), RFC ="SIL971106652" },
                    new Usuarios { Id = Guid.Parse("643e0f62-4a81-4bfb-adfb-4098f9456922"), Nombre ="PRODUCTORES UNIDOS DE LAGOS, S.C. DE R.L. DE C.V.", FechaNacimiento = DateTime.Parse("11/07/2005"), RFC ="PUL0507113N6" },
                    new Usuarios { Id = Guid.Parse("74ddfc68-a474-418a-8015-f6e084edb630"), Nombre ="ALIMENTOS PROCESADOS EL ZARCO S DE R.L. M.I. DE C.V.", FechaNacimiento = DateTime.Parse("01/02/2006"), RFC ="APZ060201412" },
                    new Usuarios { Id = Guid.Parse("522b947a-b207-4a9d-b81f-fde177f7b58c"), Nombre ="HSBC MEXICO S.A., INSTITUCION DE BANCA MULTIPLE GRUPO FINANCIERO HSBC", FechaNacimiento = DateTime.Parse("25/01/1995"), RFC ="HMI950125KG8" },
                    new Usuarios { Id = Guid.Parse("4b9bea74-897a-40c4-8579-86e008a750a2"), Nombre ="UNION GANADERA LAS TROJES", FechaNacimiento = DateTime.Parse("14/11/2005"), RFC ="UGD0511148J3" },
                    new Usuarios { Id = Guid.Parse("52251b04-4f23-499c-ab4f-c14e3623c5cb"), Nombre ="QUESOS LOS MARTINEZ, S. DE R.L. M.I. DE C.V.", FechaNacimiento = DateTime.Parse("14/06/2005"), RFC ="QMA050614F17" },
                    new Usuarios { Id = Guid.Parse("ca8b9000-563b-4344-a8c6-30586402b87f"), Nombre ="RANCHO MEDIO KILO, S. P.R. DE R.L.", FechaNacimiento = DateTime.Parse("03/02/1998"), RFC ="RMK9802033P7" },
                    new Usuarios { Id = Guid.Parse("9d727f32-2323-427d-9e94-73a7c7cf3307"), Nombre ="MARTIN RUIZ BERNAL, S. DE P.R. DE R.L.", FechaNacimiento = DateTime.Parse("20/02/2002"), RFC ="MRB0112136W7" },
                    new Usuarios { Id = Guid.Parse("0cc556d8-ec74-4459-8d1d-cefe0318726e"), Nombre ="CHIVOS Y BORREGOS DE AGUASCALIENTES, S.P.R. DE R.L", FechaNacimiento = DateTime.Parse("13/02/2006"), RFC ="CBA051107TKA" },
                    new Usuarios { Id = Guid.Parse("cbdbc958-7809-4741-b6a7-4c40b2e6518c"), Nombre ="GANADEROS UNIDOS DE TEQUILILLA", FechaNacimiento = DateTime.Parse("09/12/2002"), RFC ="GUT021209P8G" },
                    new Usuarios { Id = Guid.Parse("55f154bb-0f98-4f96-b977-2e44f199c11a"), Nombre ="COMUNIDAD PRODUCTORA 2000, S.P.R.DE R.L.", FechaNacimiento = DateTime.Parse("10/12/1999"), RFC ="CPD9912105S7" },
                    new Usuarios { Id = Guid.Parse("d892155b-1d89-48e1-8f05-a511da256087"), Nombre ="INOVAGRO, S.A. DE C.V.", FechaNacimiento = DateTime.Parse("16/06/2003"), RFC ="INO030616JN5" },
                    new Usuarios { Id = Guid.Parse("5987665e-70be-4164-8fef-87fece87b251"), Nombre ="GANADERIA LA GREÑUDA, S.C. DE R.L.", FechaNacimiento = DateTime.Parse("24/06/2006"), RFC ="GGR060624JV4" },
                    new Usuarios { Id = Guid.Parse("f91011b0-2bda-44b1-acde-621ac461a295"), Nombre ="PRODUCTORES DE LA ESTANCIA DE CUQUIO, S.C.  DE  R.L.", FechaNacimiento = DateTime.Parse("21/10/2005"), RFC ="PEC051021HX7" },
                    new Usuarios { Id = Guid.Parse("3a2c6874-89e5-43a5-a768-9ce85a6363e8"), Nombre ="GRANJA EL 13 DE LOS ACUÑA, S.P.R.  DE  R.L.", FechaNacimiento = DateTime.Parse("27/03/2004"), RFC ="GTA040327Q39" },
                    new Usuarios { Id = Guid.Parse("571d6a6e-d250-4809-b943-2dfd2aaf39ae"), Nombre ="EL GREÑERO, S. DE R.L. DE C.V.", FechaNacimiento = DateTime.Parse("08/05/2002"), RFC ="GRE0205086JA" },
                    new Usuarios { Id = Guid.Parse("97f77864-0f96-461b-8261-9b64875aceea"), Nombre ="AGRASISA, S.A. DE C.V.", FechaNacimiento = DateTime.Parse("09/11/2001"), RFC ="AGR011109ST4" }
                };

                foreach (Usuarios usurio in usuarios)
                {
                    context.Add(usurio);
                }

                context.SaveChangesAsync().Wait();
            }

            //Valida que no hayan registros de Estados
            if (!context.Estados.Any())
            {
                List<Estados> estados = new List<Estados>() {
                    new Estados {Id = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), NombreCorto = "AGS", NombreLargo = "AGUASCALIENTES" },
                    new Estados {Id = Guid.Parse("f03fb821-9038-4cf4-b39a-8479af2fed6f"), NombreCorto = "BCN", NombreLargo = "BAJA CALIFORNIA" },
                    new Estados {Id = Guid.Parse("25bbdabb-2051-4b09-a5d9-ea1657ae749c"), NombreCorto = "BCS", NombreLargo = "BAJA CALIFORNIA SUR" },
                    new Estados {Id = Guid.Parse("853c6de6-b4af-4af4-a915-e57e7de305c8"), NombreCorto = "CAMP", NombreLargo = "CAMPECHE" },
                    new Estados {Id = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), NombreCorto = "COAH", NombreLargo = "COAHUILA" },
                    new Estados {Id = Guid.Parse("51e94734-4607-46f3-9874-692397481d77"), NombreCorto = "COL", NombreLargo = "COLIMA" },
                    new Estados {Id = Guid.Parse("228430d8-03d5-4ed2-895c-f16c1c616c5b"), NombreCorto = "CHIS", NombreLargo = "CHIAPAS" },
                    new Estados {Id = Guid.Parse("62230865-4b74-4075-b287-18659107b1db"), NombreCorto = "CHIH", NombreLargo = "CHIHUAHUA" },
                    new Estados {Id = Guid.Parse("2c6d9bf2-ad9d-4d5e-87f0-87d891cb4984"), NombreCorto = "DF", NombreLargo = "DISTRITO FEDERAL" },
                    new Estados {Id = Guid.Parse("30002e5b-ab38-40dd-8dc7-6e682ad0c864"), NombreCorto = "DGO", NombreLargo = "DURANGO" },
                    new Estados {Id = Guid.Parse("be64779f-82ba-4571-bcff-73dc9fdd26df"), NombreCorto = "GTO", NombreLargo = "GUANAJUATO" },
                    new Estados {Id = Guid.Parse("50cea281-ccaa-4a01-8932-377f933ba07d"), NombreCorto = "GRO", NombreLargo = "GUERRERO" },
                    new Estados {Id = Guid.Parse("cb95b1f6-fc28-46df-9791-f8efcb793430"), NombreCorto = "HGO", NombreLargo = "HIDALGO" },
                    new Estados {Id = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), NombreCorto = "JAL", NombreLargo = "JALISCO" },
                    new Estados {Id = Guid.Parse("1131d617-4230-4b24-a032-c890ae602377"), NombreCorto = "MEX", NombreLargo = "ESTADO DE MEXICO" },
                    new Estados {Id = Guid.Parse("46a897a2-75af-4e55-9176-22260b234f1c"), NombreCorto = "MICH", NombreLargo = "MICHOACAN" },
                    new Estados {Id = Guid.Parse("1e71322a-7a3c-44a6-bc13-ae0bf17ad396"), NombreCorto = "MOR", NombreLargo = "MORELOS" },
                    new Estados {Id = Guid.Parse("11cf9000-1e4f-49e5-af9f-471d43a31fb4"), NombreCorto = "NAY", NombreLargo = "NAYARIT" },
                    new Estados {Id = Guid.Parse("7df0b967-5ed8-4fcc-9ac0-6bd385e757e3"), NombreCorto = "NL", NombreLargo = "NUEVO LEON" },
                    new Estados {Id = Guid.Parse("7a1c70f9-baa9-4a69-add1-81cf824a80eb"), NombreCorto = "OAX", NombreLargo = "OAXACA" },
                    new Estados {Id = Guid.Parse("74e733a1-fc33-4879-9e74-dff45b532d63"), NombreCorto = "PUE", NombreLargo = "PUEBLA" },
                    new Estados {Id = Guid.Parse("bb703b71-0326-4ac3-85c8-9505e51e8e06"), NombreCorto = "QRO", NombreLargo = "QUERETARO" },
                    new Estados {Id = Guid.Parse("c3db390e-8aa5-480d-bbb8-67756b35dc5d"), NombreCorto = "QROO", NombreLargo = "QUINTANA ROO" },
                    new Estados {Id = Guid.Parse("0f85c913-9631-4bd1-a8a6-58956883ff0b"), NombreCorto = "SLP", NombreLargo = "SAN LUIS POTOSI" },
                    new Estados {Id = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), NombreCorto = "SIN", NombreLargo = "SINALOA" },
                    new Estados {Id = Guid.Parse("311e9250-d080-475a-8fa1-7739eab09c26"), NombreCorto = "SON", NombreLargo = "SONORA" },
                    new Estados {Id = Guid.Parse("fbe47134-5691-4913-a894-d736b71aaac0"), NombreCorto = "TAB", NombreLargo = "TABASCO" },
                    new Estados {Id = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), NombreCorto = "TAMP", NombreLargo = "TAMAULIPAS" },
                    new Estados {Id = Guid.Parse("fdad883f-3a3e-4c0e-b58a-5f548ce348df"), NombreCorto = "TLAX", NombreLargo = "TLAXCALA" },
                    new Estados {Id = Guid.Parse("ae9610b3-5a8d-48f8-8dc9-b228ff0482b9"), NombreCorto = "VER", NombreLargo = "VERACRUZ" },
                    new Estados {Id = Guid.Parse("787695fe-1412-4912-ac09-dd500f68ca3d"), NombreCorto = "YUC", NombreLargo = "YUCATAN" },
                    new Estados {Id = Guid.Parse("a984701a-996f-4bf1-8e3e-6df37ccfddde"), NombreCorto = "ZAC", NombreLargo = "ZACATECAS" },
                    new Estados {Id = Guid.Parse("f3c85600-fe96-4f45-8062-b1b07a16ca2b"), NombreCorto = "CDMX", NombreLargo = "CIUDAD DE MÉXICO" }
                };

                foreach (Estados estado in estados)
                {
                    context.Add(estado);
                }

                context.SaveChangesAsync().Wait();
            }

            //Valida que no hayan registros de permisos
            if (!context.Permisos.Any())
            {
                List<Permisos> permisos = new List<Permisos>() {
                    new Permisos { IdUsuario = Guid.Parse("96558290-a55c-4f64-9398-2672413761c0"), IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8") },
                    new Permisos { IdUsuario = Guid.Parse("cac88536-95e3-44a1-afab-76dab7eee076"), IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd") },
                    new Permisos { IdUsuario = Guid.Parse("a8e53288-a4df-4148-9219-96429976cb0c"), IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d") },
                    new Permisos { IdUsuario = Guid.Parse("5ec13072-206b-4f91-bb47-4a0a61e36b2b"), IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167") },
                    new Permisos { IdUsuario = Guid.Parse("643e0f62-4a81-4bfb-adfb-4098f9456922"), IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6") },
                    new Permisos { IdUsuario = Guid.Parse("74ddfc68-a474-418a-8015-f6e084edb630"), IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd") },
                    new Permisos { IdUsuario = Guid.Parse("522b947a-b207-4a9d-b81f-fde177f7b58c"), IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd") },
                    new Permisos { IdUsuario = Guid.Parse("4b9bea74-897a-40c4-8579-86e008a750a2"), IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd") },
                    new Permisos { IdUsuario = Guid.Parse("52251b04-4f23-499c-ab4f-c14e3623c5cb"), IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8") },
                    new Permisos { IdUsuario = Guid.Parse("ca8b9000-563b-4344-a8c6-30586402b87f"), IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d") },
                    new Permisos { IdUsuario = Guid.Parse("9d727f32-2323-427d-9e94-73a7c7cf3307"), IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167") },
                    new Permisos { IdUsuario = Guid.Parse("0cc556d8-ec74-4459-8d1d-cefe0318726e"), IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6") },
                    new Permisos { IdUsuario = Guid.Parse("cbdbc958-7809-4741-b6a7-4c40b2e6518c"), IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6") },
                    new Permisos { IdUsuario = Guid.Parse("55f154bb-0f98-4f96-b977-2e44f199c11a"), IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6") },
                    new Permisos { IdUsuario = Guid.Parse("d892155b-1d89-48e1-8f05-a511da256087"), IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167") },
                    new Permisos { IdUsuario = Guid.Parse("5987665e-70be-4164-8fef-87fece87b251"), IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167") },
                    new Permisos { IdUsuario = Guid.Parse("f91011b0-2bda-44b1-acde-621ac461a295"), IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8") },
                    new Permisos { IdUsuario = Guid.Parse("3a2c6874-89e5-43a5-a768-9ce85a6363e8"), IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d") },
                    new Permisos { IdUsuario = Guid.Parse("571d6a6e-d250-4809-b943-2dfd2aaf39ae"), IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d") },
                    new Permisos { IdUsuario = Guid.Parse("97f77864-0f96-461b-8261-9b64875aceea"), IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8") }
                };

                foreach (Permisos permiso in permisos)
                {
                    context.Add(permiso);
                }

                context.SaveChangesAsync().Wait();

                //Valida que no hayan registros de permisos
                if (!context.Georeferencias.Any())
                {
                    List<Georeferencias> georeferencias = new List<Georeferencias>() {
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =21.13180225, Longitud =-89.50884361},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =22.302625, Longitud =102.2263139},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =23.2336, Longitud =103.3168167},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =23.23353333, Longitud =103.3335528},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =22.07935, Longitud =102.0409833},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =22.39769444, Longitud =102.2899333},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =22.39863333, Longitud =102.2900556},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =21.98357222, Longitud =102.2667667},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =21.9836, Longitud =102.2502306},
                        new Georeferencias{ IdEstado = Guid.Parse("5bb7fdf9-2291-48da-b82a-7fa00d632bd8"), Latitud =22.616775, Longitud =102.2335389},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =25.506789, Longitud =-102.2433589},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =25.50705411, Longitud =-102.2443927},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.30458298, Longitud =-103.0647895},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.30687434, Longitud =-103.0620606},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.30047677, Longitud =-103.0553136},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.29786489, Longitud =-103.0583045},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.30464132, Longitud =-103.0648854},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.30694835, Longitud =-103.0622138},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.31341072, Longitud =-103.0691436},
                        new Georeferencias{ IdEstado = Guid.Parse("0bb146b8-fa85-4d97-af8e-1e12bb97a5bd"), Latitud =26.31077704, Longitud =-103.0722422},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.20180556, Longitud =107.1031389},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =2.201583333, Longitud =107.1035556},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.22061111, Longitud =107.1337222},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.22238889, Longitud =107.1337222},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.10958333, Longitud =107.0839722},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.11113889, Longitud =107.08325},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.10941667, Longitud =107.0788889},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.10727778, Longitud =107.0763611},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.21880556, Longitud =107.1337778},
                        new Georeferencias{ IdEstado = Guid.Parse("22db02cd-1403-4518-afb3-9a9c4e12945d"), Latitud =24.22055556, Longitud =107.13375},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =20.62366667, Longitud =103.8016111},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =20.44083333, Longitud =103.9239167},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =20.48036111, Longitud =103.9556111},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =20.48425, Longitud =103.9726389},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =19.88372222, Longitud =103.372},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =19.62819444, Longitud =103.7716944},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =19.64733333, Longitud =103.7284444},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =19.65225, Longitud =103.7428056},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =19.65730556, Longitud =103.7916111},
                        new Georeferencias{ IdEstado = Guid.Parse("ee47bc7b-c843-4f80-af84-106d31058167"), Latitud =19.5935, Longitud =103.8120556},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.74877778, Longitud =97.57894444},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.30605556, Longitud =97.86688889},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.30605556, Longitud =97.86688889},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =24.61438889, Longitud =97.91577778},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.31441667, Longitud =97.79305556},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =24.61452778, Longitud =97.91575},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.29966667, Longitud =97.85988889},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.29966667, Longitud =97.85988889},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.74986111, Longitud =97.60216667},
                        new Georeferencias{ IdEstado = Guid.Parse("e36a4842-ea00-434a-b554-cc03824049e6"), Latitud =25.74986111, Longitud =97.60218611}
                    };

                    foreach (Georeferencias georeferencia in georeferencias)
                    {
                        context.Add(georeferencia);
                    }

                    context.SaveChangesAsync().Wait();
                }
            }
        }
    }
}
