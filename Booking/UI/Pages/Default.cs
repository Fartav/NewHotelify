using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DotLiquid;

namespace Booking.UI.Pages
{
    class Default
    {
        //public static string Index()
        //{
        //    Template template = Template.Parse(layout);
        //    return template.Render(Hash.FromAnonymousObject(new { page = "tobi" }));
        //}

        private static string IndexString =
            @"

            ";
        private static string layout =
            @"
                <!DOCTYPE html>
                <html lang='en'>

                <head>
                    <title>CSS Template</title>
                    <meta charset = 'utf-8' >
                    < meta name= 'viewport' content= 'width=device-width, initial-scale=1' >
                    < style >
                        * {
                            box - sizing: border - box;
                        }

                        body {
                            font-family: Arial, Helvetica, sans-serif;
                            margin: 0px;
                            padding: 0px;
                        }

                    /* Style the header */
                    header {
                            background-color: #347aeb;
                            padding: 30px;
                            text-align: center;
                            font-size: 20px;
                            color: white;
                            height: 150px;
                        }

                /* Create two columns/boxes that floats next to each other */
                nav {
                            float: right;
                            width: 20%;
                            height: 100%;
                            /* only for demonstration, should be removed */
                            background: #7fa8eb;
                            padding: 20px;
                        }

                        /* Style the list inside the menu */
                        nav ul
                {
                    list-style-type: none;
                    padding: 0;
                }

                article {
                            float: left;
                            padding: 20px;
                            width: 80%;
                            height: 100%;
                            overflow-y: scroll;
                            /* only for demonstration, should be removed */
                        }

                        section {
                            height: calc(100vh - 225px);
                        }

                        /* Clear floats after the columns */
                        section:after {
                            content: "";
                            display: table;
                            clear: both;
                        }

                        /* Style the footer */
                        footer {
                            background-color: #347aeb;
                            padding: 10px;
                            text-align: center;
                            color: white;
                            height: 75px;
                        }

                        /* Responsive layout - makes the two columns/boxes stack on top of each other instead of next to each other, on small screens */
                        @media(max-width: 600px)
                {

                    nav,
                            article {
                    width: 100 %;
                    height: auto;
                    }
                }

                table {
                            font-family: arial, sans-serif;
                            border-collapse: collapse;
                            width: 100%;
                        }

                        td,
                        th {
                            border: 1px solid #dddddd;
                            text-align: center;
                            padding: 8px;
                            direction: rtl;
                        }

                        tr:nth-child(even)
                {
                    background - color: #dddddd;
                        }
                input[type = text],
                        select {
                            width: 100%;
                            padding: 12px 20px;
                            margin: 8px 0;
                            display: inline-block;
                            border: 1px solid #ccc;
                            border-radius: 4px;
                            box-sizing: border-box;
                        }
                        input[type = submit] {
                            width: 100%;
                            background-color: #4CAF50;
                            color: white;
                            padding: 14px 20px;
                            margin: 8px 0;
                            border: none;
                            border-radius: 4px;
                            cursor: pointer;
                        }
                        input[type = submit]:hover {
                            background-color: #45a049;
                        }
                    </style>
                </head>
                <body dir = 'rtl' >
                    < header >
                       < h2 > مدیریت ماژول رزرو</h2>
                       </header>
                    <section>
                       <nav>
                            <ul>
                                <li><a href = '#' > مدیریت میزبان ها </a></li>
                                <li><a href = '#' > مدیریت رویداد ها</a></li>
                                <li><a href = '#' > مدیریت رزرو ها</a></li>
                            </ul>
                       </nav>
                       <article>
                            {{ page }}
                       </ article >
                       </ section >
                       < footer >
                           < p > لینک ها</p>
                       </footer>
                </body>
                </html>
            ";
    }
}
